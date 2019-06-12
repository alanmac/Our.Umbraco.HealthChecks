﻿using System.Collections.Generic;
using Umbraco.Core.Services;
using Umbraco.Web.HealthCheck;
using Umbraco.Web.HealthCheck.Checks.Config;

namespace Our.Umbraco.HealthChecks.Checks.Privacy
{

    [HealthCheck("4E7B05BE-F77D-4B8A-8E77-F0FB96E0BDF8", "Privacy Policy Check - (from Our.Umbraco.HealthChecks)",
        Description = "Check to ensure a Privacy Policy is selected.",
        Group = "Privacy")]
    public class PrivacyPolicyCheck : AbstractConfigCheck
    {
        private ILocalizedTextService _textService;

        public PrivacyPolicyCheck(ILocalizedTextService textService) : base(textService)
        {
            _textService = textService;
        }

        public override string FilePath => "~/Web.config";

        public override string XPath => "/configuration/appSettings/add[@key='Our.Umbraco.HealthChecks.Privacy.PrivacyPolicyUDI']/@value";

        public override ValueComparisonType ValueComparisonType => ValueComparisonType.ShouldNotEqual;

        public override ProvidedValuePropertyType ProvidedValuePropertyType => ProvidedValuePropertyType.ContentPicker;

        public override IEnumerable<AcceptableConfiguration> Values => new List<AcceptableConfiguration>
        {
            new AcceptableConfiguration { IsRecommended = false, Value = string.Empty }
        };


        public override string CheckSuccessMessage => _textService.Localize("Our.Umbraco.HealthChecks/privacyPolicyConfigSuccess");

        public override string CheckErrorMessage => _textService.Localize("Our.Umbraco.HealthChecks/privacyPolicyError");

        public override string RectifySuccessMessage => _textService.Localize("Our.Umbraco.HealthChecks/privacyPolicyRectifySuccess");

        public override string MissingErrorMessage => _textService.Localize("Our.Umbraco.HealthChecks/privacyPolicyConfigMissing");
    }

}
