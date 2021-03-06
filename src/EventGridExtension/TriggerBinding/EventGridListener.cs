﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    internal class EventGridListener : Host.Listeners.IListener
    {
        public ITriggeredFunctionExecutor Executor { private set; get; }
        public readonly bool SingleDispatch;

        private EventGridExtensionConfigProvider _listenersStore;
        private readonly string _functionName;

        public EventGridListener(ITriggeredFunctionExecutor executor, EventGridExtensionConfigProvider listenersStore, string functionName, bool singleDispatch)
        {
            _listenersStore = listenersStore;
            _functionName = functionName;
            SingleDispatch = singleDispatch;
            Executor = executor;

            // Register the listener as part of create time initialization
            _listenersStore.AddListener(_functionName, this);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public void Dispose()
        {
        }

        public void Cancel()
        {
        }
    }
}
