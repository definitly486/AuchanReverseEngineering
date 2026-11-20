package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class K7 implements Converter {
    public final H7 a;

    /* JADX WARN: Multi-variable type inference failed */
    public K7() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final ContentValues fromModel(J7 j7) {
        ContentValues contentValues = new ContentValues();
        Long l = j7.a;
        if (l != null) {
            contentValues.put("id", Long.valueOf(l.longValue()));
        }
        EnumC0523pl enumC0523pl = j7.b;
        if (enumC0523pl != null) {
            contentValues.put("type", Integer.valueOf(enumC0523pl.a));
        }
        String str = j7.c;
        if (str != null) {
            contentValues.put("report_request_parameters", str);
        }
        H7 h7 = this.a;
        contentValues.put("session_description", MessageNano.toByteArray(h7.a.fromModel(j7.d)));
        return contentValues;
    }

    public K7(H7 h7) {
        this.a = h7;
    }

    public /* synthetic */ K7(H7 h7, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new H7(null, 1, null) : h7);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final J7 toModel(ContentValues contentValues) {
        EnumC0523pl enumC0523pl;
        Long asLong = contentValues.getAsLong("id");
        Integer asInteger = contentValues.getAsInteger("type");
        if (asInteger != null) {
            int iIntValue = asInteger.intValue();
            enumC0523pl = EnumC0523pl.FOREGROUND;
            if (iIntValue != 0 && iIntValue == 1) {
                enumC0523pl = EnumC0523pl.BACKGROUND;
            }
        } else {
            enumC0523pl = null;
        }
        return new J7(asLong, enumC0523pl, contentValues.getAsString("report_request_parameters"), this.a.toModel(contentValues.getAsByteArray("session_description")));
    }
}
