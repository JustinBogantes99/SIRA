﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atestados.UIProcess.WCF_ServicioAtestados {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="oRespuestaOfArrayOfConfiguracionhHNjng7V", Namespace="http://schemas.datacontract.org/2004/07/Atestados.Objetos.Clases")]
    [System.SerializableAttribute()]
    public partial class oRespuestaOfArrayOfConfiguracionhHNjng7V : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CodigoRespuestaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeRespuestaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<Atestados.UIProcess.WCF_ServicioAtestados.Configuracion> ObjetoRespuestaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CodigoRespuesta {
            get {
                return this.CodigoRespuestaField;
            }
            set {
                if ((this.CodigoRespuestaField.Equals(value) != true)) {
                    this.CodigoRespuestaField = value;
                    this.RaisePropertyChanged("CodigoRespuesta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((this.EstadoField.Equals(value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MensajeRespuesta {
            get {
                return this.MensajeRespuestaField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeRespuestaField, value) != true)) {
                    this.MensajeRespuestaField = value;
                    this.RaisePropertyChanged("MensajeRespuesta");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<Atestados.UIProcess.WCF_ServicioAtestados.Configuracion> ObjetoRespuesta {
            get {
                return this.ObjetoRespuestaField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjetoRespuestaField, value) != true)) {
                    this.ObjetoRespuestaField = value;
                    this.RaisePropertyChanged("ObjetoRespuesta");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Configuracion", Namespace="http://schemas.datacontract.org/2004/07/Atestados.Objetos.Clases")]
    [System.SerializableAttribute()]
    public partial class Configuracion : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EstadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdConfiguracionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTipoConfiguracionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TipoConfiguracionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ValorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Estado {
            get {
                return this.EstadoField;
            }
            set {
                if ((this.EstadoField.Equals(value) != true)) {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdConfiguracion {
            get {
                return this.IdConfiguracionField;
            }
            set {
                if ((this.IdConfiguracionField.Equals(value) != true)) {
                    this.IdConfiguracionField = value;
                    this.RaisePropertyChanged("IdConfiguracion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTipoConfiguracion {
            get {
                return this.IdTipoConfiguracionField;
            }
            set {
                if ((this.IdTipoConfiguracionField.Equals(value) != true)) {
                    this.IdTipoConfiguracionField = value;
                    this.RaisePropertyChanged("IdTipoConfiguracion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoConfiguracion {
            get {
                return this.TipoConfiguracionField;
            }
            set {
                if ((object.ReferenceEquals(this.TipoConfiguracionField, value) != true)) {
                    this.TipoConfiguracionField = value;
                    this.RaisePropertyChanged("TipoConfiguracion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Valor {
            get {
                return this.ValorField;
            }
            set {
                if ((this.ValorField.Equals(value) != true)) {
                    this.ValorField = value;
                    this.RaisePropertyChanged("Valor");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCF_ServicioAtestados.IServiciosAtestados")]
    public interface IServiciosAtestados {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiciosAtestados/ConsultarConfiguracion", ReplyAction="http://tempuri.org/IServiciosAtestados/ConsultarConfiguracionResponse")]
        Atestados.UIProcess.WCF_ServicioAtestados.oRespuestaOfArrayOfConfiguracionhHNjng7V ConsultarConfiguracion(System.Nullable<int> idConfiguracion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiciosAtestados/ConsultarConfiguracion", ReplyAction="http://tempuri.org/IServiciosAtestados/ConsultarConfiguracionResponse")]
        System.Threading.Tasks.Task<Atestados.UIProcess.WCF_ServicioAtestados.oRespuestaOfArrayOfConfiguracionhHNjng7V> ConsultarConfiguracionAsync(System.Nullable<int> idConfiguracion);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiciosAtestadosChannel : Atestados.UIProcess.WCF_ServicioAtestados.IServiciosAtestados, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiciosAtestadosClient : System.ServiceModel.ClientBase<Atestados.UIProcess.WCF_ServicioAtestados.IServiciosAtestados>, Atestados.UIProcess.WCF_ServicioAtestados.IServiciosAtestados {
        
        public ServiciosAtestadosClient() {
        }
        
        public ServiciosAtestadosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiciosAtestadosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiciosAtestadosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiciosAtestadosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Atestados.UIProcess.WCF_ServicioAtestados.oRespuestaOfArrayOfConfiguracionhHNjng7V ConsultarConfiguracion(System.Nullable<int> idConfiguracion) {
            return base.Channel.ConsultarConfiguracion(idConfiguracion);
        }
        
        public System.Threading.Tasks.Task<Atestados.UIProcess.WCF_ServicioAtestados.oRespuestaOfArrayOfConfiguracionhHNjng7V> ConsultarConfiguracionAsync(System.Nullable<int> idConfiguracion) {
            return base.Channel.ConsultarConfiguracionAsync(idConfiguracion);
        }
    }
}
