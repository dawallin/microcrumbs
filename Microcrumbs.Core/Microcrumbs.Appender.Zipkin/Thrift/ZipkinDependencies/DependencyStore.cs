/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

public partial class DependencyStore {
  public interface Iface {
    void storeDependencies(Dependencies dependencies);
    #if SILVERLIGHT
    IAsyncResult Begin_storeDependencies(AsyncCallback callback, object state, Dependencies dependencies);
    void End_storeDependencies(IAsyncResult asyncResult);
    #endif
    Dependencies getDependencies(long start_time, long end_time);
    #if SILVERLIGHT
    IAsyncResult Begin_getDependencies(AsyncCallback callback, object state, long start_time, long end_time);
    Dependencies End_getDependencies(IAsyncResult asyncResult);
    #endif
  }

  public class Client : IDisposable, Iface {
    public Client(TProtocol prot) : this(prot, prot)
    {
    }

    public Client(TProtocol iprot, TProtocol oprot)
    {
      iprot_ = iprot;
      oprot_ = oprot;
    }

    protected TProtocol iprot_;
    protected TProtocol oprot_;
    protected int seqid_;

    public TProtocol InputProtocol
    {
      get { return iprot_; }
    }
    public TProtocol OutputProtocol
    {
      get { return oprot_; }
    }


    #region " IDisposable Support "
    private bool _IsDisposed;

    // IDisposable
    public void Dispose()
    {
      Dispose(true);
    }
    

    protected virtual void Dispose(bool disposing)
    {
      if (!_IsDisposed)
      {
        if (disposing)
        {
          if (iprot_ != null)
          {
            ((IDisposable)iprot_).Dispose();
          }
          if (oprot_ != null)
          {
            ((IDisposable)oprot_).Dispose();
          }
        }
      }
      _IsDisposed = true;
    }
    #endregion


    
    #if SILVERLIGHT
    public IAsyncResult Begin_storeDependencies(AsyncCallback callback, object state, Dependencies dependencies)
    {
      return send_storeDependencies(callback, state, dependencies);
    }

    public void End_storeDependencies(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      recv_storeDependencies();
    }

    #endif

    public void storeDependencies(Dependencies dependencies)
    {
      #if !SILVERLIGHT
      send_storeDependencies(dependencies);
      recv_storeDependencies();

      #else
      var asyncResult = Begin_storeDependencies(null, null, dependencies);
      End_storeDependencies(asyncResult);

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_storeDependencies(AsyncCallback callback, object state, Dependencies dependencies)
    #else
    public void send_storeDependencies(Dependencies dependencies)
    #endif
    {
      oprot_.WriteMessageBegin(new TMessage("storeDependencies", TMessageType.Call, seqid_));
      storeDependencies_args args = new storeDependencies_args();
      args.Dependencies = dependencies;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      #if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
      oprot_.Transport.Flush();
      #endif
    }

    public void recv_storeDependencies()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      storeDependencies_result result = new storeDependencies_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.e) {
        throw result.E;
      }
      return;
    }

    
    #if SILVERLIGHT
    public IAsyncResult Begin_getDependencies(AsyncCallback callback, object state, long start_time, long end_time)
    {
      return send_getDependencies(callback, state, start_time, end_time);
    }

    public Dependencies End_getDependencies(IAsyncResult asyncResult)
    {
      oprot_.Transport.EndFlush(asyncResult);
      return recv_getDependencies();
    }

    #endif

    public Dependencies getDependencies(long start_time, long end_time)
    {
      #if !SILVERLIGHT
      send_getDependencies(start_time, end_time);
      return recv_getDependencies();

      #else
      var asyncResult = Begin_getDependencies(null, null, start_time, end_time);
      return End_getDependencies(asyncResult);

      #endif
    }
    #if SILVERLIGHT
    public IAsyncResult send_getDependencies(AsyncCallback callback, object state, long start_time, long end_time)
    #else
    public void send_getDependencies(long start_time, long end_time)
    #endif
    {
      oprot_.WriteMessageBegin(new TMessage("getDependencies", TMessageType.Call, seqid_));
      getDependencies_args args = new getDependencies_args();
      args.Start_time = start_time;
      args.End_time = end_time;
      args.Write(oprot_);
      oprot_.WriteMessageEnd();
      #if SILVERLIGHT
      return oprot_.Transport.BeginFlush(callback, state);
      #else
      oprot_.Transport.Flush();
      #endif
    }

    public Dependencies recv_getDependencies()
    {
      TMessage msg = iprot_.ReadMessageBegin();
      if (msg.Type == TMessageType.Exception) {
        TApplicationException x = TApplicationException.Read(iprot_);
        iprot_.ReadMessageEnd();
        throw x;
      }
      getDependencies_result result = new getDependencies_result();
      result.Read(iprot_);
      iprot_.ReadMessageEnd();
      if (result.__isset.success) {
        return result.Success;
      }
      if (result.__isset.qe) {
        throw result.Qe;
      }
      throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "getDependencies failed: unknown result");
    }

  }
  public class Processor : TProcessor {
    public Processor(Iface iface)
    {
      iface_ = iface;
      processMap_["storeDependencies"] = storeDependencies_Process;
      processMap_["getDependencies"] = getDependencies_Process;
    }

    protected delegate void ProcessFunction(int seqid, TProtocol iprot, TProtocol oprot);
    private Iface iface_;
    protected Dictionary<string, ProcessFunction> processMap_ = new Dictionary<string, ProcessFunction>();

    public bool Process(TProtocol iprot, TProtocol oprot)
    {
      try
      {
        TMessage msg = iprot.ReadMessageBegin();
        ProcessFunction fn;
        processMap_.TryGetValue(msg.Name, out fn);
        if (fn == null) {
          TProtocolUtil.Skip(iprot, TType.Struct);
          iprot.ReadMessageEnd();
          TApplicationException x = new TApplicationException (TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
          oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
          x.Write(oprot);
          oprot.WriteMessageEnd();
          oprot.Transport.Flush();
          return true;
        }
        fn(msg.SeqID, iprot, oprot);
      }
      catch (IOException)
      {
        return false;
      }
      return true;
    }

    public void storeDependencies_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      storeDependencies_args args = new storeDependencies_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      storeDependencies_result result = new storeDependencies_result();
      try {
        iface_.storeDependencies(args.Dependencies);
      } catch (DependenciesException e) {
        result.E = e;
      }
      oprot.WriteMessageBegin(new TMessage("storeDependencies", TMessageType.Reply, seqid)); 
      result.Write(oprot);
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

    public void getDependencies_Process(int seqid, TProtocol iprot, TProtocol oprot)
    {
      getDependencies_args args = new getDependencies_args();
      args.Read(iprot);
      iprot.ReadMessageEnd();
      getDependencies_result result = new getDependencies_result();
      try {
        result.Success = iface_.getDependencies(args.Start_time, args.End_time);
      } catch (DependenciesException qe) {
        result.Qe = qe;
      }
      oprot.WriteMessageBegin(new TMessage("getDependencies", TMessageType.Reply, seqid)); 
      result.Write(oprot);
      oprot.WriteMessageEnd();
      oprot.Transport.Flush();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class storeDependencies_args : TBase
  {
    private Dependencies _dependencies;

    /// <summary>
    /// replaces the links defined for the given interval
    /// </summary>
    public Dependencies Dependencies
    {
      get
      {
        return _dependencies;
      }
      set
      {
        __isset.dependencies = true;
        this._dependencies = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool dependencies;
    }

    public storeDependencies_args() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.Struct) {
              Dependencies = new Dependencies();
              Dependencies.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("storeDependencies_args");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Dependencies != null && __isset.dependencies) {
        field.Name = "dependencies";
        field.Type = TType.Struct;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        Dependencies.Write(oprot);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("storeDependencies_args(");
      bool __first = true;
      if (Dependencies != null && __isset.dependencies) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Dependencies: ");
        __sb.Append(Dependencies== null ? "<null>" : Dependencies.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class storeDependencies_result : TBase
  {
    private DependenciesException _e;

    public DependenciesException E
    {
      get
      {
        return _e;
      }
      set
      {
        __isset.e = true;
        this._e = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool e;
    }

    public storeDependencies_result() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.Struct) {
              E = new DependenciesException();
              E.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("storeDependencies_result");
      oprot.WriteStructBegin(struc);
      TField field = new TField();

      if (this.__isset.e) {
        if (E != null) {
          field.Name = "E";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          E.Write(oprot);
          oprot.WriteFieldEnd();
        }
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("storeDependencies_result(");
      bool __first = true;
      if (E != null && __isset.e) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("E: ");
        __sb.Append(E== null ? "<null>" : E.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class getDependencies_args : TBase
  {
    private long _start_time;
    private long _end_time;

    public long Start_time
    {
      get
      {
        return _start_time;
      }
      set
      {
        __isset.start_time = true;
        this._start_time = value;
      }
    }

    public long End_time
    {
      get
      {
        return _end_time;
      }
      set
      {
        __isset.end_time = true;
        this._end_time = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool start_time;
      public bool end_time;
    }

    public getDependencies_args() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I64) {
              Start_time = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I64) {
              End_time = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("getDependencies_args");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.start_time) {
        field.Name = "start_time";
        field.Type = TType.I64;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Start_time);
        oprot.WriteFieldEnd();
      }
      if (__isset.end_time) {
        field.Name = "end_time";
        field.Type = TType.I64;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(End_time);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("getDependencies_args(");
      bool __first = true;
      if (__isset.start_time) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Start_time: ");
        __sb.Append(Start_time);
      }
      if (__isset.end_time) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("End_time: ");
        __sb.Append(End_time);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }


  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class getDependencies_result : TBase
  {
    private Dependencies _success;
    private DependenciesException _qe;

    public Dependencies Success
    {
      get
      {
        return _success;
      }
      set
      {
        __isset.success = true;
        this._success = value;
      }
    }

    public DependenciesException Qe
    {
      get
      {
        return _qe;
      }
      set
      {
        __isset.qe = true;
        this._qe = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool success;
      public bool qe;
    }

    public getDependencies_result() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 0:
            if (field.Type == TType.Struct) {
              Success = new Dependencies();
              Success.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 1:
            if (field.Type == TType.Struct) {
              Qe = new DependenciesException();
              Qe.Read(iprot);
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("getDependencies_result");
      oprot.WriteStructBegin(struc);
      TField field = new TField();

      if (this.__isset.success) {
        if (Success != null) {
          field.Name = "Success";
          field.Type = TType.Struct;
          field.ID = 0;
          oprot.WriteFieldBegin(field);
          Success.Write(oprot);
          oprot.WriteFieldEnd();
        }
      } else if (this.__isset.qe) {
        if (Qe != null) {
          field.Name = "Qe";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          Qe.Write(oprot);
          oprot.WriteFieldEnd();
        }
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("getDependencies_result(");
      bool __first = true;
      if (Success != null && __isset.success) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Success: ");
        __sb.Append(Success== null ? "<null>" : Success.ToString());
      }
      if (Qe != null && __isset.qe) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Qe: ");
        __sb.Append(Qe== null ? "<null>" : Qe.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
