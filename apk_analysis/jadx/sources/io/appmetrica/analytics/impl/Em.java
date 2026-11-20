package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.protobuf.nano.CodedInputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.InternalNano;
import io.appmetrica.analytics.protobuf.nano.InvalidProtocolBufferNanoException;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import io.appmetrica.analytics.protobuf.nano.WireFormatNano;

/* JADX INFO: loaded from: classes3.dex */
public final class Em extends MessageNano {
    public static volatile Em[] b;
    public Dm[] a;

    public Em() {
        a();
    }

    public static Em[] b() {
        if (b == null) {
            synchronized (InternalNano.LAZY_INIT_LOCK) {
                try {
                    if (b == null) {
                        b = new Em[0];
                    }
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        return b;
    }

    public final Em a() {
        this.a = Dm.b();
        this.cachedSize = -1;
        return this;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final int computeSerializedSize() {
        int iComputeSerializedSize = super.computeSerializedSize();
        Dm[] dmArr = this.a;
        if (dmArr != null && dmArr.length > 0) {
            int i = 0;
            while (true) {
                Dm[] dmArr2 = this.a;
                if (i >= dmArr2.length) {
                    break;
                }
                Dm dm = dmArr2[i];
                if (dm != null) {
                    iComputeSerializedSize = CodedOutputByteBufferNano.computeMessageSize(1, dm) + iComputeSerializedSize;
                }
                i++;
            }
        }
        return iComputeSerializedSize;
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    public final void writeTo(CodedOutputByteBufferNano codedOutputByteBufferNano) throws CodedOutputByteBufferNano.OutOfSpaceException {
        Dm[] dmArr = this.a;
        if (dmArr != null && dmArr.length > 0) {
            int i = 0;
            while (true) {
                Dm[] dmArr2 = this.a;
                if (i >= dmArr2.length) {
                    break;
                }
                Dm dm = dmArr2[i];
                if (dm != null) {
                    codedOutputByteBufferNano.writeMessage(1, dm);
                }
                i++;
            }
        }
        super.writeTo(codedOutputByteBufferNano);
    }

    @Override // io.appmetrica.analytics.protobuf.nano.MessageNano
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Em mergeFrom(CodedInputByteBufferNano codedInputByteBufferNano) throws InvalidProtocolBufferNanoException {
        while (true) {
            int tag = codedInputByteBufferNano.readTag();
            if (tag == 0) {
                break;
            }
            if (tag != 10) {
                if (!WireFormatNano.parseUnknownField(codedInputByteBufferNano, tag)) {
                    break;
                }
            } else {
                int repeatedFieldArrayLength = WireFormatNano.getRepeatedFieldArrayLength(codedInputByteBufferNano, 10);
                Dm[] dmArr = this.a;
                int length = dmArr == null ? 0 : dmArr.length;
                int i = repeatedFieldArrayLength + length;
                Dm[] dmArr2 = new Dm[i];
                if (length != 0) {
                    System.arraycopy(dmArr, 0, dmArr2, 0, length);
                }
                while (length < i - 1) {
                    Dm dm = new Dm();
                    dmArr2[length] = dm;
                    codedInputByteBufferNano.readMessage(dm);
                    codedInputByteBufferNano.readTag();
                    length++;
                }
                Dm dm2 = new Dm();
                dmArr2[length] = dm2;
                codedInputByteBufferNano.readMessage(dm2);
                this.a = dmArr2;
            }
        }
        return this;
    }

    public static Em b(CodedInputByteBufferNano codedInputByteBufferNano) {
        return new Em().mergeFrom(codedInputByteBufferNano);
    }

    public static Em a(byte[] bArr) {
        return (Em) MessageNano.mergeFrom(new Em(), bArr);
    }
}
