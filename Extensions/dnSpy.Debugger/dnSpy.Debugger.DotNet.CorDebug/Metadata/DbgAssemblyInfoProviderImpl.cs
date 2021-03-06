/*
    Copyright (C) 2014-2019 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.ComponentModel.Composition;
using dnSpy.Contracts.Debugger;
using dnSpy.Contracts.Debugger.DotNet.Metadata;
using dnSpy.Debugger.DotNet.CorDebug.Impl;

namespace dnSpy.Debugger.DotNet.CorDebug.Metadata {
	[Export(typeof(DbgAssemblyInfoProviderFactory))]
	sealed class DbgAssemblyInfoProviderFactoryImpl : DbgAssemblyInfoProviderFactory {
		public override DbgAssemblyInfoProvider Create(DbgRuntime runtime) {
			var engine = DbgEngineImpl.TryGetEngine(runtime);
			if (engine != null)
				return new DbgAssemblyInfoProviderImpl(engine);
			return null;
		}
	}

	sealed class DbgAssemblyInfoProviderImpl : DbgAssemblyInfoProvider {
		readonly DbgEngineImpl engine;
		public DbgAssemblyInfoProviderImpl(DbgEngineImpl engine) => this.engine = engine;
		public override DbgModule[] GetAssemblyModules(DbgModule module) => engine.GetAssemblyModules(module);
	}
}
