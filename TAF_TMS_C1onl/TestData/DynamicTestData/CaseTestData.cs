using System.Collections;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.TestData.DynamicTestData
{
    internal class CaseTitleRandomData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(FakerHelper.Faker.Lorem.Word() + " case");
            }
        }
    }

    internal class CaseTitleConfigData
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(TestDataHelper.GetTestEntity<Case>("GeneralCase").Title);
            }
        }
    }
}