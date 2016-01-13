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


/// <summary>
/// Associates an event that explains latency with a timestamp.
/// 
/// Unlike log statements, annotations are often codes: for example "sr".
/// </summary>
#if !SILVERLIGHT
[Serializable]
#endif
public partial class Annotation : TBase
{
  private long _timestamp;
  private string _value;
  private Endpoint _host;

  /// <summary>
  /// Microseconds from epoch.
  /// 
  /// This value should use the most precise value possible. For example,
  /// gettimeofday or syncing nanoTime against a tick of currentTimeMillis.
  /// </summary>
  public long Timestamp
  {
    get
    {
      return _timestamp;
    }
    set
    {
      __isset.timestamp = true;
      this._timestamp = value;
    }
  }

  /// <summary>
  /// Usually a short tag indicating an event, like "sr" or "finagle.retry".
  /// </summary>
  public string Value
  {
    get
    {
      return _value;
    }
    set
    {
      __isset.@value = true;
      this._value = value;
    }
  }

  /// <summary>
  /// The host that recorded the value, primarily for query by service name.
  /// </summary>
  public Endpoint Host
  {
    get
    {
      return _host;
    }
    set
    {
      __isset.host = true;
      this._host = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool timestamp;
    public bool @value;
    public bool host;
  }

  public Annotation() {
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
            Timestamp = iprot.ReadI64();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 2:
          if (field.Type == TType.String) {
            Value = iprot.ReadString();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 3:
          if (field.Type == TType.Struct) {
            Host = new Endpoint();
            Host.Read(iprot);
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
    TStruct struc = new TStruct("Annotation");
    oprot.WriteStructBegin(struc);
    TField field = new TField();
    if (__isset.timestamp) {
      field.Name = "timestamp";
      field.Type = TType.I64;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI64(Timestamp);
      oprot.WriteFieldEnd();
    }
    if (Value != null && __isset.@value) {
      field.Name = "value";
      field.Type = TType.String;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Value);
      oprot.WriteFieldEnd();
    }
    if (Host != null && __isset.host) {
      field.Name = "host";
      field.Type = TType.Struct;
      field.ID = 3;
      oprot.WriteFieldBegin(field);
      Host.Write(oprot);
      oprot.WriteFieldEnd();
    }
    oprot.WriteFieldStop();
    oprot.WriteStructEnd();
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("Annotation(");
    bool __first = true;
    if (__isset.timestamp) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Timestamp: ");
      __sb.Append(Timestamp);
    }
    if (Value != null && __isset.@value) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Value: ");
      __sb.Append(Value);
    }
    if (Host != null && __isset.host) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Host: ");
      __sb.Append(Host== null ? "<null>" : Host.ToString());
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

