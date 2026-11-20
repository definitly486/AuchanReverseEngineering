package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class Ff extends MessageNano {
    public static volatile Ff[] f;
    public String a;
    public String b;
    public boolean c;
    public boolean d;
    public int e;

    public Ff() {
        a();
    }

    public static Ff[] b() {
        if (f == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (f == null) {
                        f = new Ff[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return f;
    }

    public final Ff a() {
        this.a = "";
        this.b = "";
        this.c = false;
        this.d = false;
        this.e = 0;
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        if (!this.a.equals("")) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeStringSize(1, this.a);
        }
        if (!this.b.equals("")) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeStringSize(2, this.b);
        }
        boolean z = this.c;
        if (z) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeBoolSize(3, z);
        }
        boolean z2 = this.d;
        if (z2) {
            iComputeSerializedSize += CodedOutputByteBufferNano.computeBoolSize(4, z2);
        }
        return CodedOutputByteBufferNano.computeInt32Size(5, this.e) + iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        if (!this.a.equals("")) {
            codedOutputByteBufferNano.writeString(1, this.a);
        }
        if (!this.b.equals("")) {
            codedOutputByteBufferNano.writeString(2, this.b);
        }
        boolean z = this.c;
        if (z) {
            codedOutputByteBufferNano.writeBool(3, z);
        }
        boolean z2 = this.d;
        if (z2) {
            codedOutputByteBufferNano.writeBool(4, z2);
        }
        codedOutputByteBufferNano.writeInt32(5, this.e);
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Ff mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag == 10) {
                this.a = codedInputByteBufferNano.readString();
            } else if (tag == 18) {
                this.b = codedInputByteBufferNano.readString();
            } else if (tag == 24) {
                this.c = codedInputByteBufferNano.readBool();
            } else if (tag == 32) {
                this.d = codedInputByteBufferNano.readBool();
            } else if (tag != 40) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int int32 = codedInputByteBufferNano.readInt32();
                if (int32 == 0 || int32 == 1 || int32 == 2 || int32 == 3) {
                    this.e = int32;
                }
            }
        }
        return this;
    }

    public static Ff b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new Ff().mergeFrom(codedInputByteBufferNano);
    }

    public static Ff a(byte[] bArr) {
        return (Ff) MessageNano.mergeFrom(new Ff(), bArr);
    }
}
