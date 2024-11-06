using System;

namespace DevelopmentChallenge.Data.Attributes
{
    public  class TipoFormaAttribute : Attribute
    {
        public string TipoForma { get; }

        public TipoFormaAttribute(string tipoForma)
        {
            TipoForma = tipoForma;
        }
    }
}
