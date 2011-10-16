﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.1
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Der Quellcode wurde automatisch mit Microsoft.VSDesigner generiert. Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace NME2.Nme2Ws {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="Nme2WsBinding", Namespace="http://nyx/soap/Nme2Ws")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(CustomObject))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(MissionObject))]
    public partial class Nme2Ws : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback MissionServiceGetMissionsWithinOperationCompleted;
        
        private System.Threading.SendOrPostCallback MissionObjectServiceGetMissionObjectsForMissionsOperationCompleted;
        
        private System.Threading.SendOrPostCallback MissionObjectServiceGetAllMissionObjectsForMissionsOperationCompleted;
        
        private System.Threading.SendOrPostCallback MissionServiceGetAllMissionsAsArrayOperationCompleted;
        
        private System.Threading.SendOrPostCallback SimObjectServiceGetAllSimObjectsAsArrayOperationCompleted;
        
        private System.Threading.SendOrPostCallback CustomObjectServiceGetAllCustomObjectsAsArrayOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Nme2Ws() {
            this.Url = global::NME2.Properties.Settings.Default.NME2_Nme2Ws_Nme2Ws;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event MissionServiceGetMissionsWithinCompletedEventHandler MissionServiceGetMissionsWithinCompleted;
        
        /// <remarks/>
        public event MissionObjectServiceGetMissionObjectsForMissionsCompletedEventHandler MissionObjectServiceGetMissionObjectsForMissionsCompleted;
        
        /// <remarks/>
        public event MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventHandler MissionObjectServiceGetAllMissionObjectsForMissionsCompleted;
        
        /// <remarks/>
        public event MissionServiceGetAllMissionsAsArrayCompletedEventHandler MissionServiceGetAllMissionsAsArrayCompleted;
        
        /// <remarks/>
        public event SimObjectServiceGetAllSimObjectsAsArrayCompletedEventHandler SimObjectServiceGetAllSimObjectsAsArrayCompleted;
        
        /// <remarks/>
        public event CustomObjectServiceGetAllCustomObjectsAsArrayCompletedEventHandler CustomObjectServiceGetAllCustomObjectsAsArrayCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:nme2#getmission", RequestNamespace="urn:nme2", ResponseNamespace="urn:nme2")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public Mission[] MissionServiceGetMissionsWithin(double lat, double lon) {
            object[] results = this.Invoke("MissionServiceGetMissionsWithin", new object[] {
                        lat,
                        lon});
            return ((Mission[])(results[0]));
        }
        
        /// <remarks/>
        public void MissionServiceGetMissionsWithinAsync(double lat, double lon) {
            this.MissionServiceGetMissionsWithinAsync(lat, lon, null);
        }
        
        /// <remarks/>
        public void MissionServiceGetMissionsWithinAsync(double lat, double lon, object userState) {
            if ((this.MissionServiceGetMissionsWithinOperationCompleted == null)) {
                this.MissionServiceGetMissionsWithinOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMissionServiceGetMissionsWithinOperationCompleted);
            }
            this.InvokeAsync("MissionServiceGetMissionsWithin", new object[] {
                        lat,
                        lon}, this.MissionServiceGetMissionsWithinOperationCompleted, userState);
        }
        
        private void OnMissionServiceGetMissionsWithinOperationCompleted(object arg) {
            if ((this.MissionServiceGetMissionsWithinCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MissionServiceGetMissionsWithinCompleted(this, new MissionServiceGetMissionsWithinCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:nme2#getmissionobjects", RequestNamespace="urn:nme2", ResponseNamespace="urn:nme2")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public MissionObject[] MissionObjectServiceGetMissionObjectsForMissions(Mission[] missions) {
            object[] results = this.Invoke("MissionObjectServiceGetMissionObjectsForMissions", new object[] {
                        missions});
            return ((MissionObject[])(results[0]));
        }
        
        /// <remarks/>
        public void MissionObjectServiceGetMissionObjectsForMissionsAsync(Mission[] missions) {
            this.MissionObjectServiceGetMissionObjectsForMissionsAsync(missions, null);
        }
        
        /// <remarks/>
        public void MissionObjectServiceGetMissionObjectsForMissionsAsync(Mission[] missions, object userState) {
            if ((this.MissionObjectServiceGetMissionObjectsForMissionsOperationCompleted == null)) {
                this.MissionObjectServiceGetMissionObjectsForMissionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMissionObjectServiceGetMissionObjectsForMissionsOperationCompleted);
            }
            this.InvokeAsync("MissionObjectServiceGetMissionObjectsForMissions", new object[] {
                        missions}, this.MissionObjectServiceGetMissionObjectsForMissionsOperationCompleted, userState);
        }
        
        private void OnMissionObjectServiceGetMissionObjectsForMissionsOperationCompleted(object arg) {
            if ((this.MissionObjectServiceGetMissionObjectsForMissionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MissionObjectServiceGetMissionObjectsForMissionsCompleted(this, new MissionObjectServiceGetMissionObjectsForMissionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:nme2#getallmissionobjects", RequestNamespace="urn:nme2", ResponseNamespace="urn:nme2")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public MissionObject[] MissionObjectServiceGetAllMissionObjectsForMissions(Mission[] missions) {
            object[] results = this.Invoke("MissionObjectServiceGetAllMissionObjectsForMissions", new object[] {
                        missions});
            return ((MissionObject[])(results[0]));
        }
        
        /// <remarks/>
        public void MissionObjectServiceGetAllMissionObjectsForMissionsAsync(Mission[] missions) {
            this.MissionObjectServiceGetAllMissionObjectsForMissionsAsync(missions, null);
        }
        
        /// <remarks/>
        public void MissionObjectServiceGetAllMissionObjectsForMissionsAsync(Mission[] missions, object userState) {
            if ((this.MissionObjectServiceGetAllMissionObjectsForMissionsOperationCompleted == null)) {
                this.MissionObjectServiceGetAllMissionObjectsForMissionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMissionObjectServiceGetAllMissionObjectsForMissionsOperationCompleted);
            }
            this.InvokeAsync("MissionObjectServiceGetAllMissionObjectsForMissions", new object[] {
                        missions}, this.MissionObjectServiceGetAllMissionObjectsForMissionsOperationCompleted, userState);
        }
        
        private void OnMissionObjectServiceGetAllMissionObjectsForMissionsOperationCompleted(object arg) {
            if ((this.MissionObjectServiceGetAllMissionObjectsForMissionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MissionObjectServiceGetAllMissionObjectsForMissionsCompleted(this, new MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:nme2#getallmissions", RequestNamespace="urn:nme2", ResponseNamespace="urn:nme2")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public Mission[] MissionServiceGetAllMissionsAsArray() {
            object[] results = this.Invoke("MissionServiceGetAllMissionsAsArray", new object[0]);
            return ((Mission[])(results[0]));
        }
        
        /// <remarks/>
        public void MissionServiceGetAllMissionsAsArrayAsync() {
            this.MissionServiceGetAllMissionsAsArrayAsync(null);
        }
        
        /// <remarks/>
        public void MissionServiceGetAllMissionsAsArrayAsync(object userState) {
            if ((this.MissionServiceGetAllMissionsAsArrayOperationCompleted == null)) {
                this.MissionServiceGetAllMissionsAsArrayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMissionServiceGetAllMissionsAsArrayOperationCompleted);
            }
            this.InvokeAsync("MissionServiceGetAllMissionsAsArray", new object[0], this.MissionServiceGetAllMissionsAsArrayOperationCompleted, userState);
        }
        
        private void OnMissionServiceGetAllMissionsAsArrayOperationCompleted(object arg) {
            if ((this.MissionServiceGetAllMissionsAsArrayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MissionServiceGetAllMissionsAsArrayCompleted(this, new MissionServiceGetAllMissionsAsArrayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:nme2#getallsimobjects", RequestNamespace="urn:nme2", ResponseNamespace="urn:nme2")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public SimObject[] SimObjectServiceGetAllSimObjectsAsArray() {
            object[] results = this.Invoke("SimObjectServiceGetAllSimObjectsAsArray", new object[0]);
            return ((SimObject[])(results[0]));
        }
        
        /// <remarks/>
        public void SimObjectServiceGetAllSimObjectsAsArrayAsync() {
            this.SimObjectServiceGetAllSimObjectsAsArrayAsync(null);
        }
        
        /// <remarks/>
        public void SimObjectServiceGetAllSimObjectsAsArrayAsync(object userState) {
            if ((this.SimObjectServiceGetAllSimObjectsAsArrayOperationCompleted == null)) {
                this.SimObjectServiceGetAllSimObjectsAsArrayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSimObjectServiceGetAllSimObjectsAsArrayOperationCompleted);
            }
            this.InvokeAsync("SimObjectServiceGetAllSimObjectsAsArray", new object[0], this.SimObjectServiceGetAllSimObjectsAsArrayOperationCompleted, userState);
        }
        
        private void OnSimObjectServiceGetAllSimObjectsAsArrayOperationCompleted(object arg) {
            if ((this.SimObjectServiceGetAllSimObjectsAsArrayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SimObjectServiceGetAllSimObjectsAsArrayCompleted(this, new SimObjectServiceGetAllSimObjectsAsArrayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:nme2#getallcustomobjects", RequestNamespace="urn:nme2", ResponseNamespace="urn:nme2")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public CustomObject[] CustomObjectServiceGetAllCustomObjectsAsArray() {
            object[] results = this.Invoke("CustomObjectServiceGetAllCustomObjectsAsArray", new object[0]);
            return ((CustomObject[])(results[0]));
        }
        
        /// <remarks/>
        public void CustomObjectServiceGetAllCustomObjectsAsArrayAsync() {
            this.CustomObjectServiceGetAllCustomObjectsAsArrayAsync(null);
        }
        
        /// <remarks/>
        public void CustomObjectServiceGetAllCustomObjectsAsArrayAsync(object userState) {
            if ((this.CustomObjectServiceGetAllCustomObjectsAsArrayOperationCompleted == null)) {
                this.CustomObjectServiceGetAllCustomObjectsAsArrayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCustomObjectServiceGetAllCustomObjectsAsArrayOperationCompleted);
            }
            this.InvokeAsync("CustomObjectServiceGetAllCustomObjectsAsArray", new object[0], this.CustomObjectServiceGetAllCustomObjectsAsArrayOperationCompleted, userState);
        }
        
        private void OnCustomObjectServiceGetAllCustomObjectsAsArrayOperationCompleted(object arg) {
            if ((this.CustomObjectServiceGetAllCustomObjectsAsArrayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CustomObjectServiceGetAllCustomObjectsAsArrayCompleted(this, new CustomObjectServiceGetAllCustomObjectsAsArrayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://nyx/soap/Nme2Ws")]
    public partial class Mission {
        
        private int idField;
        
        private string nameField;
        
        private string versionField;
        
        private double centerLatField;
        
        private double centerLonField;
        
        private int missionRangeField;
        
        private int activeField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        public double CenterLat {
            get {
                return this.centerLatField;
            }
            set {
                this.centerLatField = value;
            }
        }
        
        /// <remarks/>
        public double CenterLon {
            get {
                return this.centerLonField;
            }
            set {
                this.centerLonField = value;
            }
        }
        
        /// <remarks/>
        public int MissionRange {
            get {
                return this.missionRangeField;
            }
            set {
                this.missionRangeField = value;
            }
        }
        
        /// <remarks/>
        public int Active {
            get {
                return this.activeField;
            }
            set {
                this.activeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://nyx/soap/Nme2Ws")]
    public partial class CustomObject {
        
        private int idField;
        
        private string versionField;
        
        private string downloadPathField;
        
        private string descriptionField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        public string DownloadPath {
            get {
                return this.downloadPathField;
            }
            set {
                this.downloadPathField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://nyx/soap/Nme2Ws")]
    public partial class SimObject {
        
        private int idField;
        
        private string nameField;
        
        private string simNameField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string SimName {
            get {
                return this.simNameField;
            }
            set {
                this.simNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://nyx/soap/Nme2Ws")]
    public partial class MissionObject {
        
        private int idField;
        
        private int mission_IdField;
        
        private Mission missionField;
        
        private int simObject_IdField;
        
        private SimObject simobjectField;
        
        private double latField;
        
        private double lonField;
        
        private float altitudeField;
        
        private int onGroundField;
        
        private double pitchField;
        
        private double yawField;
        
        private double bankField;
        
        private int headingField;
        
        private int activeField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public int Mission_Id {
            get {
                return this.mission_IdField;
            }
            set {
                this.mission_IdField = value;
            }
        }
        
        /// <remarks/>
        public Mission Mission {
            get {
                return this.missionField;
            }
            set {
                this.missionField = value;
            }
        }
        
        /// <remarks/>
        public int SimObject_Id {
            get {
                return this.simObject_IdField;
            }
            set {
                this.simObject_IdField = value;
            }
        }
        
        /// <remarks/>
        public SimObject Simobject {
            get {
                return this.simobjectField;
            }
            set {
                this.simobjectField = value;
            }
        }
        
        /// <remarks/>
        public double Lat {
            get {
                return this.latField;
            }
            set {
                this.latField = value;
            }
        }
        
        /// <remarks/>
        public double Lon {
            get {
                return this.lonField;
            }
            set {
                this.lonField = value;
            }
        }
        
        /// <remarks/>
        public float Altitude {
            get {
                return this.altitudeField;
            }
            set {
                this.altitudeField = value;
            }
        }
        
        /// <remarks/>
        public int OnGround {
            get {
                return this.onGroundField;
            }
            set {
                this.onGroundField = value;
            }
        }
        
        /// <remarks/>
        public double Pitch {
            get {
                return this.pitchField;
            }
            set {
                this.pitchField = value;
            }
        }
        
        /// <remarks/>
        public double Yaw {
            get {
                return this.yawField;
            }
            set {
                this.yawField = value;
            }
        }
        
        /// <remarks/>
        public double Bank {
            get {
                return this.bankField;
            }
            set {
                this.bankField = value;
            }
        }
        
        /// <remarks/>
        public int Heading {
            get {
                return this.headingField;
            }
            set {
                this.headingField = value;
            }
        }
        
        /// <remarks/>
        public int Active {
            get {
                return this.activeField;
            }
            set {
                this.activeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MissionServiceGetMissionsWithinCompletedEventHandler(object sender, MissionServiceGetMissionsWithinCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MissionServiceGetMissionsWithinCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MissionServiceGetMissionsWithinCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Mission[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Mission[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MissionObjectServiceGetMissionObjectsForMissionsCompletedEventHandler(object sender, MissionObjectServiceGetMissionObjectsForMissionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MissionObjectServiceGetMissionObjectsForMissionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MissionObjectServiceGetMissionObjectsForMissionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MissionObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MissionObject[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventHandler(object sender, MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MissionObjectServiceGetAllMissionObjectsForMissionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public MissionObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((MissionObject[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void MissionServiceGetAllMissionsAsArrayCompletedEventHandler(object sender, MissionServiceGetAllMissionsAsArrayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MissionServiceGetAllMissionsAsArrayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MissionServiceGetAllMissionsAsArrayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Mission[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Mission[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SimObjectServiceGetAllSimObjectsAsArrayCompletedEventHandler(object sender, SimObjectServiceGetAllSimObjectsAsArrayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SimObjectServiceGetAllSimObjectsAsArrayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SimObjectServiceGetAllSimObjectsAsArrayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public SimObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((SimObject[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CustomObjectServiceGetAllCustomObjectsAsArrayCompletedEventHandler(object sender, CustomObjectServiceGetAllCustomObjectsAsArrayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CustomObjectServiceGetAllCustomObjectsAsArrayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CustomObjectServiceGetAllCustomObjectsAsArrayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public CustomObject[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((CustomObject[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591