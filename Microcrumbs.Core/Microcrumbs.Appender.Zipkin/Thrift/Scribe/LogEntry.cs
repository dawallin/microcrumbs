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


#if !SILVERLIGHT
[Serializable]
#endif
public partial class LogEntry : TBase
{
  private string _category;
  private string _message;

  public string Category
  {
    get
    {
      return _category;
    }
    set
    {
      __isset.category = true;
      this._category = value;
    }
  }

  public string Message
  {
    get
    {
      return _message;
    }
    set
    {
      __isset.message = true;
      this._message = value;
    }
  }


  public Isset __isset;
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public struct Isset {
    public bool category;
    public bool message;
  }

  public LogEntry() {
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
          if (field.Type == TType.String) {
            Category = iprot.ReadString();
          } else { 
            TProtocolUtil.Skip(iprot, field.Type);
          }
          break;
        case 2:
          if (field.Type == TType.String) {
            Message = iprot.ReadString();
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
    TStruct struc = new TStruct("LogEntry");
    oprot.WriteStructBegin(struc);
    TField field = new TField();
    if (Category != null && __isset.category) {
      field.Name = "category";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Category);
      oprot.WriteFieldEnd();
    }
    if (Message != null && __isset.message) {
      field.Name = "message";
      field.Type = TType.String;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Message);
      oprot.WriteFieldEnd();
    }
    oprot.WriteFieldStop();
    oprot.WriteStructEnd();
  }

  public override string ToString() {
    StringBuilder __sb = new StringBuilder("LogEntry(");
    bool __first = true;
    if (Category != null && __isset.category) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Category: ");
      __sb.Append(Category);
    }
    if (Message != null && __isset.message) {
      if(!__first) { __sb.Append(", "); }
      __first = false;
      __sb.Append("Message: ");
      __sb.Append(Message);
    }
    __sb.Append(")");
    return __sb.ToString();
  }

}

