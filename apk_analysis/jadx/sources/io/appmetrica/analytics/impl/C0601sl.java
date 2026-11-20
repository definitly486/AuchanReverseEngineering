package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.Iterator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.sl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0601sl {
    public final InterfaceC0712x2 a;

    public C0601sl(InterfaceC0712x2 interfaceC0712x2) {
        this.a = interfaceC0712x2;
    }

    public final ArrayList a(Iterable iterable) {
        String hexString;
        ArrayList arrayList = new ArrayList();
        Iterator it = iterable.iterator();
        while (it.hasNext()) {
            String str = (String) it.next();
            try {
                String strA = this.a.a(str);
                if (strA == null || (hexString = StringUtils.toHexString(MessageDigest.getInstance("SHA-256").digest(strA.getBytes(Charsets.UTF_8)))) == null) {
                    PublicLogger.Companion.getAnonymousInstance().info("Input " + str + " is not a valid data", new Object[0]);
                    hexString = null;
                }
            } catch (NoSuchAlgorithmException unused) {
            }
            if (hexString != null) {
                arrayList.add(hexString);
            }
        }
        return arrayList;
    }
}
