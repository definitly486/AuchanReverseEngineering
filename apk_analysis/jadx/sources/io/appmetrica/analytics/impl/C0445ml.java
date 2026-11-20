package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ml, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0445ml {
    public final Cdo a;
    public final InterfaceC0435mb b;

    public C0445ml(C0505p3 c0505p3, C0263fk c0263fk) {
        this.a = c0505p3;
        this.b = c0263fk;
    }

    public final Si a(long j, C0771z9 c0771z9, List list, C0727xh c0727xh, int i, C0234eh c0234eh) {
        boolean z;
        C0745y9 c0745y9A;
        int iComputeMessageSize;
        C0485o9 c0485o9;
        ArrayList arrayList = new ArrayList();
        int i2 = c0234eh.a;
        int i3 = c0234eh.b;
        Integer num = c0234eh.c;
        Iterator it = list.iterator();
        int i4 = i3;
        C0372k0 c0372k0 = null;
        int iComputeMessageSize2 = i2;
        Integer numValueOf = num;
        while (true) {
            if (it.hasNext()) {
                ContentValues contentValues = (ContentValues) it.next();
                if (i4 < 100) {
                    C0304h9 c0304h9 = new C0304h9(contentValues);
                    try {
                        EnumC0721xb enumC0721xb = c0304h9.h;
                        if (enumC0721xb != null) {
                            c0485o9 = (C0485o9) AbstractC0388kg.d.get(enumC0721xb);
                        } else {
                            Map map = AbstractC0388kg.a;
                            c0485o9 = null;
                        }
                        if (c0485o9 == null) {
                            c0485o9 = C0485o9.i;
                        }
                        try {
                            c0745y9A = c0485o9.a(c0304h9, c0727xh);
                        } catch (Throwable th) {
                            th = th;
                            this.b.reportError("protobuf_serialization_error", th);
                            c0745y9A = null;
                        }
                    } catch (Throwable th2) {
                        th = th2;
                    }
                    if (c0745y9A != null) {
                        String str = c0304h9.u;
                        C0372k0 c0372k1 = new C0372k0(str, c0304h9.v);
                        if (c0372k0 != null) {
                            if (!Intrinsics.areEqual(c0372k0, c0372k1)) {
                                z = true;
                                break;
                            }
                        } else {
                            if (numValueOf == null) {
                                try {
                                    JSONObject jSONObject = new JSONObject(str);
                                    Iterator<String> itKeys = jSONObject.keys();
                                    iComputeMessageSize = 0;
                                    while (itKeys.hasNext()) {
                                        String next = itKeys.next();
                                        C0589s9 c0589s9 = new C0589s9();
                                        c0589s9.a = next;
                                        c0589s9.b = jSONObject.getString(next);
                                        iComputeMessageSize += CodedOutputByteBufferNano.computeMessageSize(7, c0589s9);
                                    }
                                } catch (Throwable unused) {
                                    iComputeMessageSize = 0;
                                }
                                numValueOf = Integer.valueOf(iComputeMessageSize);
                                iComputeMessageSize2 += iComputeMessageSize;
                            }
                            c0372k0 = c0372k1;
                        }
                        byte[] bArr = (byte[]) this.a.a(c0745y9A.e);
                        byte[] bArr2 = c0745y9A.e;
                        if (bArr2 != bArr) {
                            c0745y9A.i = ((bArr2 != null ? bArr2.length : 0) - (bArr != null ? bArr.length : 0)) + c0745y9A.i;
                            c0745y9A.e = bArr;
                        }
                        iComputeMessageSize2 += CodedOutputByteBufferNano.computeMessageSize(3, c0745y9A);
                        if (arrayList.isEmpty() && i == 0) {
                            if (iComputeMessageSize2 >= 1048576) {
                            }
                            arrayList.add(c0745y9A);
                        } else {
                            if (iComputeMessageSize2 >= 250880) {
                            }
                            arrayList.add(c0745y9A);
                        }
                    }
                    i4++;
                }
            }
            z = false;
            break;
        }
        if (arrayList.isEmpty()) {
            return null;
        }
        A9 a9 = new A9();
        a9.a = j;
        a9.b = c0771z9;
        a9.c = (C0745y9[]) arrayList.toArray(new C0745y9[0]);
        return new Si(a9, c0372k0, z, iComputeMessageSize2, i4, numValueOf);
    }
}
