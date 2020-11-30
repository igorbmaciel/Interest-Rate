using InterestCalculation.Domain.AppConst;
using Tnf.Configuration;
using Tnf.Localization;
using Tnf.Localization.Dictionaries;


namespace InterestCalculation.Domain
{
    public static class LocalizationExtensions
    {
        public static void UseDomainLocalization(this ITnfConfiguration configuration)
        {
            configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(AppConsts.LocalizationSourceName,
                new JsonEmbeddedFileLocalizationDictionaryProvider(
                    typeof(LocalizationExtensions).Assembly,
                    "InterestCalculation.Domain.Localization.SourceFiles")));

            configuration.Localization.Languages.Add(new LanguageInfo("pt-BR", "Português", isDefault: true));
        }
    }
}
