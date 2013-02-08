﻿// <copyright file="DefaultPageExecutor.cs" company="Katana contributors">
//   Copyright 2011-2013 Katana contributors
// </copyright>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Threading.Tasks;
using Gate;

namespace Microsoft.AspNet.Razor.Owin.Execution
{
    public class DefaultPageExecutor : IPageExecutor
    {
        public Task Execute(IRazorPage page, Request request, ITrace tracer)
        {
            Requires.NotNull(page, "page");
            Requires.NotNull(request, "request");
            Requires.NotNull(tracer, "tracer");

            return ExecuteCore(page, request, tracer);
        }

        private static async Task ExecuteCore(IRazorPage page, Request request, ITrace tracer)
        {
            var resp = new Response(request.Environment);
            await page.Run(request, resp);
        }
    }
}