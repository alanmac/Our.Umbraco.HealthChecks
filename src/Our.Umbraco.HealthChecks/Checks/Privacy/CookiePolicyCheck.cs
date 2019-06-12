using System.Collections.Generic;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;
using Umbraco.Web.HealthCheck.Checks.Config;

namespace Our.Umbraco.HealthChecks.Checks.Privacy
{

    [HealthCheck("4A616B92-AC7C-4CA0-9F77-08E8543AEC8E", "Cookie Policy Check - (from Our.Umbraco.HealthChecks)",
        Description = "Check to ensure a Cookie Policy is selected.",
        Group = "Privacy")]
    public class CookiePolicyCheck : AbstractConfigCheck
    {
        private ILocalizedTextService _textService;

        public CookiePolicyCheck(ILocalizedTextService textService) : base(textService)
        {
            _textService = textService;
        }

        public override string FilePath => "~/Web.config";

        public override string XPath => "/configuration/appSettings/add[@key='Our.Umbraco.HealthChecks.Privacy.CookiePolicyUDI']/@value";

        public override ValueComparisonType ValueComparisonType => ValueComparisonType.ShouldNotEqual;

        public override ProvidedValuePropertyType ProvidedValuePropertyType => ProvidedValuePropertyType.ContentPicker;

        public override IEnumerable<AcceptableConfiguration> Values => new List<AcceptableConfiguration>
        {
            new AcceptableConfiguration { IsRecommended = false, Value = string.Empty }
        };

        public override string CheckSuccessMessage => _textService.Localize("Our.Umbraco.HealthChecks/cookiePolicyConfigSuccess");

        public override string CheckErrorMessage => _textService.Localize("Our.Umbraco.HealthChecks/cookiePolicyError");

        public override string RectifySuccessMessage => _textService.Localize("Our.Umbraco.HealthChecks/cookiePolicyRectifySuccess");

        public override string MissingErrorMessage => _textService.Localize("Our.Umbraco.HealthChecks/cookiePolicyConfigMissing");
    }

}
