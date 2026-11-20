package com.scanflow.datacapture.barinternal.kotlin.uuid;

import com.scanflow.datacapture.barinternal.kotlin.ULong;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import java.io.Serializable;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import org.tensorflow.lite.schema.BuiltinOptions;

/* JADX INFO: compiled from: Uuid.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Uuid implements Comparable, Serializable {
    public static final Companion Companion = new Companion(null);
    private static final Uuid NIL = new Uuid(0, 0);
    private final long leastSignificantBits;
    private final long mostSignificantBits;

    public /* synthetic */ Uuid(long j, long j2, DefaultConstructorMarker defaultConstructorMarker) {
        this(j, j2);
    }

    private Uuid(long j, long j2) {
        this.mostSignificantBits = j;
        this.leastSignificantBits = j2;
    }

    public String toString() {
        return toHexDashString();
    }

    public final String toHexDashString() {
        byte[] bArr = new byte[36];
        UuidKt__UuidJVMKt.formatBytesInto(this.mostSignificantBits, bArr, 0, 0, 4);
        bArr[8] = BuiltinOptions.GreaterEqualOptions;
        UuidKt__UuidJVMKt.formatBytesInto(this.mostSignificantBits, bArr, 9, 4, 6);
        bArr[13] = BuiltinOptions.GreaterEqualOptions;
        UuidKt__UuidJVMKt.formatBytesInto(this.mostSignificantBits, bArr, 14, 6, 8);
        bArr[18] = BuiltinOptions.GreaterEqualOptions;
        UuidKt__UuidJVMKt.formatBytesInto(this.leastSignificantBits, bArr, 19, 0, 2);
        bArr[23] = BuiltinOptions.GreaterEqualOptions;
        UuidKt__UuidJVMKt.formatBytesInto(this.leastSignificantBits, bArr, 24, 2, 8);
        return StringsKt.decodeToString(bArr);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Uuid)) {
            return false;
        }
        Uuid uuid = (Uuid) obj;
        return this.mostSignificantBits == uuid.mostSignificantBits && this.leastSignificantBits == uuid.leastSignificantBits;
    }

    @Override // java.lang.Comparable
    public int compareTo(Uuid other) {
        Intrinsics.checkNotNullParameter(other, "other");
        long j = this.mostSignificantBits;
        if (j != other.mostSignificantBits) {
            return Long.compareUnsigned(ULong.m734constructorimpl(j), ULong.m734constructorimpl(other.mostSignificantBits));
        }
        return Long.compareUnsigned(ULong.m734constructorimpl(this.leastSignificantBits), ULong.m734constructorimpl(other.leastSignificantBits));
    }

    public int hashCode() {
        return Long.hashCode(this.mostSignificantBits ^ this.leastSignificantBits);
    }

    /* JADX INFO: compiled from: Uuid.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final Uuid getNIL() {
            return Uuid.NIL;
        }

        public final Uuid fromLongs(long j, long j2) {
            if (j == 0 && j2 == 0) {
                return getNIL();
            }
            return new Uuid(j, j2, null);
        }

        public final Uuid parse(String uuidString) {
            Intrinsics.checkNotNullParameter(uuidString, "uuidString");
            int length = uuidString.length();
            if (length == 32) {
                return UuidKt__UuidJVMKt.uuidParseHex(uuidString);
            }
            if (length == 36) {
                return UuidKt__UuidJVMKt.uuidParseHexDash(uuidString);
            }
            throw new IllegalArgumentException("Expected either a 36-char string in the standard hex-and-dash UUID format or a 32-char hexadecimal string, but was \"" + UuidKt__UuidKt.truncateForErrorMessage$UuidKt__UuidKt(uuidString, 64) + "\" of length " + uuidString.length());
        }
    }
}
