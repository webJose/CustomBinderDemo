using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CustomBinderDemo.ModelBinders;

public class CustomDecimalModelBinder : IModelBinder
{
    private readonly CultureInfo _cultureInfo;

    public CustomDecimalModelBinder(CultureInfo cultureInfo)
    {
        _cultureInfo = cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo));
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }
        bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);
        var value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }
        if (decimal.TryParse(value, NumberStyles.Number, _cultureInfo, out var result))
        {
            bindingContext.Result = ModelBindingResult.Success(result);
        }
        else
        {
            bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Invalid decimal value.");
        }
        return Task.CompletedTask;
    }
}

public class CustomDecimalModelBinderFactory : IModelBinderProvider
{
    private readonly CultureInfo _cultureInfo;

    public CustomDecimalModelBinderFactory(CultureInfo cultureInfo)
    {
        _cultureInfo = cultureInfo ?? throw new ArgumentNullException(nameof(cultureInfo));
    }

    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        if (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))
        {
            return new CustomDecimalModelBinder(_cultureInfo);
        }
        return null;
    }
}
