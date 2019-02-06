using SageAufbaukursCSharp.Services;

namespace SageAufbaukursCSharp.ServiceImplementations
{
    public class PartnerUtilImpl : IPartnerUtil
    { 
        public bool TestState { get; set; }        

        public bool IsConnected
        {
            get
            {
                return TestState;
            } 
        }
    }
}
