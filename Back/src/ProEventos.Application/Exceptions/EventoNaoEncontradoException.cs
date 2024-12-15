using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Exceptions
{
    public class EventoNaoEncontradoException : Exception
    {
        public EventoNaoEncontradoException() { }
        public EventoNaoEncontradoException(string message) : base(message) { }
        public EventoNaoEncontradoException(string message, Exception inner) : base(message, inner) { }
    }
}
