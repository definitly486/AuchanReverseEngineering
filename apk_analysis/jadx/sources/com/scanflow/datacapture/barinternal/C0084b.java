package com.scanflow.datacapture.barinternal;

import android.graphics.Color;
import android.graphics.PointF;
import android.graphics.RectF;
import java.util.Arrays;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.StringCompanionObject;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.b, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0084b {
    public final String a;
    public final String b;
    public final float c;
    public RectF d;
    public PointF e;
    public int f;

    public C0084b(String id, String title, float f, RectF location) {
        Intrinsics.checkNotNullParameter(id, "id");
        Intrinsics.checkNotNullParameter(title, "title");
        Intrinsics.checkNotNullParameter(location, "location");
        this.f = Color.parseColor("#1ab3fb");
        this.a = id;
        this.b = title;
        this.c = f;
        this.d = location;
    }

    public final String toString() {
        String str;
        if (this.a != null) {
            str = "[" + this.a + "] ";
        } else {
            str = "";
        }
        if (this.b != null) {
            str = str + this.b + ' ';
        }
        StringBuilder sb = new StringBuilder();
        sb.append(str);
        StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
        String str2 = String.format("(%.1f%%) ", Arrays.copyOf(new Object[]{Float.valueOf(this.c * 100.0f)}, 1));
        Intrinsics.checkNotNullExpressionValue(str2, "format(...)");
        sb.append(str2);
        String string = sb.toString();
        if (this.d != null) {
            string = string + this.d + ' ';
        }
        int length = string.length() - 1;
        int i = 0;
        boolean z = false;
        while (i <= length) {
            boolean z2 = Intrinsics.compare((int) string.charAt(!z ? i : length), 32) <= 0;
            if (z) {
                if (!z2) {
                    break;
                }
                length--;
            } else if (z2) {
                i++;
            } else {
                z = true;
            }
        }
        return string.subSequence(i, length + 1).toString();
    }
}
