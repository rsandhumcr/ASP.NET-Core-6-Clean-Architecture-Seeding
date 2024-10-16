﻿using FluentValidation.Results;

namespace CompanyNameSpace.ProjectName.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(ValidationResult validationResult)
    {
        ValidationErrors = new List<string>();

        foreach (var validationError in validationResult.Errors) ValidationErrors.Add(validationError.ErrorMessage);
    }

    public List<string> ValidationErrors { get; set; }
}