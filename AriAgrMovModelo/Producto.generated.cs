#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using AriAgrMovModelo;

namespace AriAgrMovModelo	
{
	public partial class Producto
	{
		private ushort _codprodu;
		public virtual ushort Codprodu
		{
			get
			{
				return this._codprodu;
			}
			set
			{
				this._codprodu = value;
			}
		}
		
		private string _nomprodu;
		public virtual string Nomprodu
		{
			get
			{
				return this._nomprodu;
			}
			set
			{
				this._nomprodu = value;
			}
		}
		
		private ushort _codgrupo;
		public virtual ushort Codgrupo
		{
			get
			{
				return this._codgrupo;
			}
			set
			{
				this._codgrupo = value;
			}
		}
		
		private ushort _codsigpa;
		public virtual ushort Codsigpa
		{
			get
			{
				return this._codsigpa;
			}
			set
			{
				this._codsigpa = value;
			}
		}
		
		private ushort _gruporeten;
		public virtual ushort Gruporeten
		{
			get
			{
				return this._gruporeten;
			}
			set
			{
				this._gruporeten = value;
			}
		}
		
		private decimal _porcepigrafe;
		public virtual decimal Porcepigrafe
		{
			get
			{
				return this._porcepigrafe;
			}
			set
			{
				this._porcepigrafe = value;
			}
		}
		
		private IList<Variedade> _variedades = new List<Variedade>();
		public virtual IList<Variedade> Variedades
		{
			get
			{
				return this._variedades;
			}
		}
		
	}
}
#pragma warning restore 1591
