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

namespace AriAgrMovModelo	
{
	public partial class Trzlineas_carga
	{
		private uint _linea;
		public virtual uint Linea
		{
			get
			{
				return this._linea;
			}
			set
			{
				this._linea = value;
			}
		}
		
		private uint _idpalet;
		public virtual uint Idpalet
		{
			get
			{
				return this._idpalet;
			}
			set
			{
				this._idpalet = value;
			}
		}
		
		private DateTime _fechahora;
		public virtual DateTime Fechahora
		{
			get
			{
				return this._fechahora;
			}
			set
			{
				this._fechahora = value;
			}
		}
		
		private DateTime _fecha;
		public virtual DateTime Fecha
		{
			get
			{
				return this._fecha;
			}
			set
			{
				this._fecha = value;
			}
		}
		
		private int _tipo;
		public virtual int Tipo
		{
			get
			{
				return this._tipo;
			}
			set
			{
				this._tipo = value;
			}
		}
		
		private string _crfid;
		public virtual string Crfid
		{
			get
			{
				return this._crfid;
			}
			set
			{
				this._crfid = value;
			}
		}
		
	}
}
#pragma warning restore 1591