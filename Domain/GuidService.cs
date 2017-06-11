using System;

namespace Domain
{
    public interface IGuidService
    {
        Guid NewGuid();
    }

    public class GuidService : IGuidService
    {
        public Guid NewGuid()
        {
            return Guid.NewGuid();
        }
    }
}