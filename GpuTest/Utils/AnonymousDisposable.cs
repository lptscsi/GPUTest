﻿using System;
using System.Threading;

namespace GpuTest
{
    /// <summary>
    /// Класс для освобождения ресурсов используя делегат
    /// </summary>
    public sealed class AnonymousDisposable : IDisposable
    {
        private readonly Action _action;
        private int _disposed;

        public AnonymousDisposable(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _disposed, 1) == 0)
            {
                _action();
            }
        }
    }
}
