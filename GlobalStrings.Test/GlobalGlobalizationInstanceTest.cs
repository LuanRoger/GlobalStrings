using GlobalStrings.Globalization;
using GlobalStrings.Test.Utils;
using Xunit;

namespace GlobalStrings.Test
{
    public class GlobalGlobalizationInstanceTest
    {
        public GlobalGlobalizationInstanceTest()
        {
            StarGlobalizationInstance();
        }
        private void StarGlobalizationInstance()
        {
            GlobalGlobalization<string, string, int>.SetInstance(new(Consts.languageInfos, "pt_br"));
        }
        
        [Fact]
        public void GetGlobalizationInAutoInitialization()
        {
            lock (GlobalGlobalization<string, string, int>.GetInstance())
            {
                GlobalGlobalization<string, string, int>.ClearGlobalInstance();
            
                GlobalGlobalization<string, string, int>.autoInstanceIfNull = true;
                GlobalGlobalization<string, string, int>.GetInstance();
                
                Assert.NotNull(GlobalGlobalization<string, string, int>.GetInstance());
            }
        }
        
        [Fact]
        public void GetGlobalizationInstanceTest()
        {
            Assert.NotNull(GlobalGlobalization<string, string, int>.GetInstance());
        }
        
        [Fact]
        public void ClearGlobalGlobalizationInstanceTest()
        {
            lock (GlobalGlobalization<string, string, int>.GetInstance())
            {
                GlobalGlobalization<string, string, int>.ClearGlobalInstance();

                Assert.Null(GlobalGlobalization<string, string, int>.GetInstance());
            }
        }
    }
}