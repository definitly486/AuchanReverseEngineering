package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.lg, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0414lg {
    public static final String a(String str, EnumC0721xb enumC0721xb, String str2, String str3) {
        if (enumC0721xb == null) {
            enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        }
        if (!Q9.d.contains(EnumC0721xb.a(enumC0721xb.a))) {
            return null;
        }
        StringBuilder sb = new StringBuilder();
        sb.append(str);
        sb.append(": ");
        sb.append(enumC0721xb.name());
        if (Q9.f.contains(enumC0721xb) && str2 != null && str2.length() != 0) {
            sb.append(" with name ");
            sb.append(str2);
        }
        if (Q9.e.contains(enumC0721xb) && str3 != null && str3.length() != 0) {
            sb.append(" with value ");
            sb.append(str3);
        }
        return sb.toString();
    }

    public static final String a(C0745y9 c0745y9) {
        String string;
        StringBuilder sb = new StringBuilder("Event sent: ");
        int i = c0745y9.c;
        String str = c0745y9.d;
        byte[] bArr = c0745y9.e;
        if (i == 1) {
            string = "Attribution";
        } else if (i == 2) {
            string = "Session start";
        } else if (i == 4) {
            if (str == null) {
                str = "null";
            }
            StringBuilder sb2 = new StringBuilder(str);
            if (bArr != null) {
                String str2 = new String(bArr, Charsets.UTF_8);
                if (str2.length() > 0) {
                    sb2.append(" with value ");
                    sb2.append(str2);
                }
            }
            string = sb2.toString();
        } else if (i == 5) {
            string = "Referrer";
        } else if (i == 7) {
            string = "Session heartbeat";
        } else if (i == 13) {
            string = "The very first event";
        } else if (i == 35) {
            string = "E-Commerce";
        } else if (i == 40) {
            string = "Ad revenue (ILRD)";
        } else if (i == 42) {
            string = "External attribution";
        } else if (i == 16) {
            string = "Open";
        } else if (i == 17) {
            string = "Update";
        } else if (i == 20) {
            string = "User profile update";
        } else if (i != 21) {
            switch (i) {
                case 25:
                    string = "ANR";
                    break;
                case 26:
                    string = "Crash: " + str;
                    break;
                case 27:
                    string = "Error: " + str;
                    break;
                default:
                    string = "type=" + i;
                    break;
            }
        } else {
            string = "Revenue";
        }
        sb.append(string);
        return sb.toString();
    }
}
