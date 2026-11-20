package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.q3, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public class C0532q3 implements InterfaceC0557r3 {
    public final int a;

    public C0532q3(int i) {
        this.a = i;
    }

    public static InterfaceC0557r3 a(InterfaceC0557r3... interfaceC0557r3Arr) {
        return new C0532q3(b(interfaceC0557r3Arr));
    }

    public static int b(InterfaceC0557r3... interfaceC0557r3Arr) {
        int bytesTruncated = 0;
        for (InterfaceC0557r3 interfaceC0557r3 : interfaceC0557r3Arr) {
            if (interfaceC0557r3 != null) {
                bytesTruncated = interfaceC0557r3.getBytesTruncated() + bytesTruncated;
            }
        }
        return bytesTruncated;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0557r3
    public final int getBytesTruncated() {
        return this.a;
    }

    public String toString() {
        return "BytesTruncatedInfo{bytesTruncated=" + this.a + '}';
    }
}
