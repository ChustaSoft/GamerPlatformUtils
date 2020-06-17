using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public abstract class FileDependantPlatformBase : IPlatform
    {

        protected readonly IReadFileRepository _readFileRepository;


        public virtual bool Available { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Brand { get; protected set; }
        public virtual string AppPath { get; protected set; }
        public virtual IEnumerable<string> Libraries { get; protected set; }



        public FileDependantPlatformBase(ServiceResolver serviceAccessor, string fileRepositoryKey)
        {
            _readFileRepository = serviceAccessor(fileRepositoryKey);

            LoadPlatform();
        }


        protected abstract void LoadPlatform();

    }
}
