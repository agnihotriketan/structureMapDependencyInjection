using structureMapDIDemo.Interface;

namespace structureMapDIDemo.Provider
{
    public class RequestValidator : IRequestValidator
    {
        public bool ValidateRequest()
        {
            return true;
        }
    }
}