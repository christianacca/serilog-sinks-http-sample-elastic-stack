using System;
using System.Runtime.CompilerServices;
using Bogus;
using Bogus.DataSets;

namespace SerilogExample.Generators
{
    public class ExceptionGenerator
    {
        private readonly Randomizer random;
        private readonly Lorem lorem;

        public ExceptionGenerator()
        {
            random = new Randomizer();
            lorem = new Lorem("en");
        }

        public Exception Generate()
        {
            bool blowUp = random.Number(0, 100) % 5 == 0;
            return blowUp ? GenerateRealException() : null;
        }



        [MethodImpl(MethodImplOptions.NoInlining)]
        private Exception GenerateRealException()
        {
            try
            {
                ThrowException();
            }
            catch (System.Exception ex)
            {
                return ex;
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private Exception ThrowException()
        {
            throw new Exception($"Some random error {lorem.Paragraphs(2)}");
        }
    }
}