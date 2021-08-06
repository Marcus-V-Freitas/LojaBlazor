namespace LojaBlazor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Resultado
    {
        private readonly List<string> erros;

        internal Resultado(bool succeeded, List<string> errors)
        {
            this.Sucesso = succeeded;
            this.erros = errors;
        }

        public bool Sucesso { get; }

        public List<string> Erros
            => this.Sucesso
                ? new List<string>()
                : this.erros;

        public static Resultado Success
            => new Resultado(true, new List<string>());

        public static Resultado Failure(IEnumerable<string> errors)
            => new Resultado(false, errors.ToList());

        public static implicit operator Resultado(string error)
            => Failure(new List<string> { error });

        public static implicit operator Resultado(List<string> errors)
            => Failure(errors.ToList());

        public static implicit operator Resultado(bool success)
            => success ? Success : Failure(new[] { "Unsuccessful operation." });

        public static implicit operator bool(Resultado result)
            => result.Sucesso;
    }

    public class Result<TData> : Resultado
    {
        private readonly TData data;

        private Result(bool succeeded, TData data, List<string> errors)
            : base(succeeded, errors)
            => this.data = data;

        public TData Data
            => this.Sucesso
                ? this.data
                : throw new InvalidOperationException(
                    $"{nameof(this.Data)} is not available with a failed result. Use {this.Erros} instead.");

        public static Result<TData> SuccessWith(TData data)
            => new Result<TData>(true, data, new List<string>());

        public new static Result<TData> Failure(IEnumerable<string> errors)
            => new Result<TData>(false, default, errors.ToList());

        public static implicit operator Result<TData>(string error)
            => Failure(new List<string> { error });

        public static implicit operator Result<TData>(List<string> errors)
            => Failure(errors);

        public static implicit operator Result<TData>(TData data)
            => SuccessWith(data);

        public static implicit operator bool(Result<TData> result)
            => result.Sucesso;
    }
}
