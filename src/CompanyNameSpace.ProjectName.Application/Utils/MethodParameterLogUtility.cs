using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using Newtonsoft.Json;

namespace CompanyNameSpace.ProjectName.Application.Utils;

//var parameterData = new MethodParameterLogUtility(() => parameterValue).GetParameterValues();
//var parameterData = new MethodParameterLogUtility(() => parameterOne, () => parameterTwo).GetParameterValues();

public class MethodParameterLogUtility
{
    private string _methodName;
    private string _paramaterLog;

    private readonly Dictionary<string, Type> _methodParamaters;
    private readonly List<Tuple<string, Type, object>> _providedParametars;

    public MethodParameterLogUtility(params Expression<Func<object>>[] providedParameters)
    {
        try
        {
            var currentMethod = new StackTrace().GetFrame(1).GetMethod();

            /*Set class and current method info*/
            _methodName = String.Format("Class = {0}, Method = {1}", currentMethod.DeclaringType.FullName, currentMethod.Name);

            /*Get current methods parameters*/
            _methodParamaters = new Dictionary<string, Type>();
            (from aParamater in currentMethod.GetParameters()
             select new { Name = aParamater.Name, DataType = aParamater.ParameterType })
             .ToList()
             .ForEach(obj => _methodParamaters.Add(obj.Name, obj.DataType));

            /*Get provided methods parameters*/
            _providedParametars = new List<Tuple<string, Type, object>>();
            foreach (var aExpression in providedParameters)
            {
                Expression bodyType = aExpression.Body;

                if (bodyType is MemberExpression)
                {
                    AddProvidedParamaterDetail((MemberExpression)aExpression.Body);
                }
                else if (bodyType is UnaryExpression)
                {
                    UnaryExpression unaryExpression = (UnaryExpression)aExpression.Body;
                    AddProvidedParamaterDetail((MemberExpression)unaryExpression.Operand);
                }
                else
                {
                    throw new Exception("Expression type unknown.");
                }
            }

            /*Process log for all method parameters*/
            ProcessLog();

        }
        catch (Exception exception)
        {
            throw new Exception("Error in paramater log processing.", exception);
        }
    }

    private void ProcessLog()
    {
        try
        {
            foreach (var methodParameter in _methodParamaters)
            {
                var aParameter =
                    _providedParametars.Where(
                        obj => obj.Item1.Equals(methodParameter.Key) && obj.Item2 == methodParameter.Value).Single();
                _paramaterLog += String.Format(@" ""{0}"":{1},", aParameter.Item1, JsonConvert.SerializeObject(aParameter.Item3));
            }
            _paramaterLog = (_paramaterLog != null) ? _paramaterLog.Trim(' ', ',') : string.Empty;
        }
        catch (Exception exception)
        {
            throw new Exception($"Method Paramater is not found in providedParameters. {exception.Message}");
        }
    }

    private void AddProvidedParamaterDetail(MemberExpression memberExpression)
    {
        ConstantExpression constantExpression = (ConstantExpression)memberExpression.Expression;
        var name = memberExpression.Member.Name;
        var value = ((FieldInfo)memberExpression.Member).GetValue(constantExpression?.Value);
        var type = value?.GetType();
        _providedParametars.Add(new Tuple<string, Type, object>(name, type, value));
    }


    public string GetParameterValues()
    {
        var parameterValues = $"{_methodName}({_paramaterLog})";
        return parameterValues
            .Replace(",\"", ", \"")
            .Replace("\":{", "\": {");
    }

}
