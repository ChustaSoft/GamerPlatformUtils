using System.Collections.Generic;

namespace ChustaSoft.GamersPlatformUtils.Abstractions
{
    public abstract class PlatformBase : IPlatform
    {

        public virtual bool Available { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string Brand { get; protected set; }
        public virtual string AppPath { get; protected set; }
        public virtual IEnumerable<string> Libraries { get; protected set; }


        public PlatformBase()
        {
            LoadPlatform();
        }


        protected abstract void LoadPlatform();

    }
}