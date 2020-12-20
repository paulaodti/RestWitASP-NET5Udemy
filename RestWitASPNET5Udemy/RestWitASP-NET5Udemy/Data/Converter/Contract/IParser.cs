using System.Collections.Generic;

namespace RestWitASP_NET5Udemy.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origins);
    }
}
