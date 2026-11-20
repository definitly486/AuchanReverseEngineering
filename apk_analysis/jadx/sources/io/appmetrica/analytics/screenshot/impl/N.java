package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class N extends MessageNano {
    public static volatile N[] d;
    public K a;
    public M b;
    public L c;

    public N() {
        a();
    }

    public static N[] b() {
        if (d == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (d == null) {
                        d = new N[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return d;
    }

    public final N a() {
        this.a = null;
        this.b = null;
        this.c = null;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        K k = this.a;
        if (k != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(1, k);
        }
        M m = this.b;
        if (m != null) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeMessageSize(2, m);
        }
        L l = this.c;
        return l != null ? CodedOutputByteBufferNano.computeMessageSize(3, l) + iComputeSerializedSize : iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        K k = this.a;
        if (k != null) {
            codedOutputByteBufferNano.writeMessage(1, k);
        }
        M m = this.b;
        if (m != null) {
            codedOutputByteBufferNano.writeMessage(2, m);
        }
        L l = this.c;
        if (l != null) {
            codedOutputByteBufferNano.writeMessage(3, l);
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final N mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                if (this.a == null) {
                    this.a = new K();
                }
                codedInputByteBufferNano.readMessage(this.a);
            } else if (tag == 18) {
                if (this.b == null) {
                    this.b = new M();
                }
                codedInputByteBufferNano.readMessage(this.b);
            } else if (tag != 26) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                if (this.c == null) {
                    this.c = new L();
                }
                codedInputByteBufferNano.readMessage(this.c);
            }
        }
        return this;
    }

    public static N b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new N().mergeFrom(codedInputByteBufferNano);
    }

    public static N a(byte[] bArr) {
        return (N) MessageNano.mergeFrom(new N(), bArr);
    }
}
