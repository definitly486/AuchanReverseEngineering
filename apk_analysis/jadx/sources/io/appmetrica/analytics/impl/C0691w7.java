package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.w7, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0691w7 implements Converter {
    public final C0613t7 a;

    /* JADX WARN: Multi-variable type inference failed */
    public C0691w7() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final ContentValues fromModel(C0665v7 c0665v7) {
        ContentValues contentValues = new ContentValues();
        Long l = c0665v7.a;
        if (l != null) {
            contentValues.put("session_id", Long.valueOf(l.longValue()));
        }
        EnumC0523pl enumC0523pl = c0665v7.b;
        if (enumC0523pl != null) {
            contentValues.put("session_type", Integer.valueOf(enumC0523pl.a));
        }
        Long l2 = c0665v7.c;
        if (l2 != null) {
            contentValues.put("number_in_session", Long.valueOf(l2.longValue()));
        }
        EnumC0721xb enumC0721xb = c0665v7.d;
        if (enumC0721xb != null) {
            contentValues.put("type", Integer.valueOf(enumC0721xb.a));
        }
        Long l3 = c0665v7.e;
        if (l3 != null) {
            contentValues.put("global_number", Long.valueOf(l3.longValue()));
        }
        Long l4 = c0665v7.f;
        if (l4 != null) {
            contentValues.put("time", Long.valueOf(l4.longValue()));
        }
        C0613t7 c0613t7 = this.a;
        contentValues.put("event_description", MessageNano.toByteArray(c0613t7.a.fromModel(c0665v7.g)));
        return contentValues;
    }

    public C0691w7(C0613t7 c0613t7) {
        this.a = c0613t7;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public /* synthetic */ C0691w7(C0613t7 c0613t7, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? new C0613t7(null, 1, 0 == true ? 1 : 0) : c0613t7);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0665v7 toModel(ContentValues contentValues) {
        EnumC0523pl enumC0523pl;
        Long asLong = contentValues.getAsLong("session_id");
        Integer asInteger = contentValues.getAsInteger("session_type");
        if (asInteger != null) {
            int iIntValue = asInteger.intValue();
            enumC0523pl = EnumC0523pl.FOREGROUND;
            if (iIntValue != 0 && iIntValue == 1) {
                enumC0523pl = EnumC0523pl.BACKGROUND;
            }
        } else {
            enumC0523pl = null;
        }
        Long asLong2 = contentValues.getAsLong("number_in_session");
        Integer asInteger2 = contentValues.getAsInteger("type");
        return new C0665v7(asLong, enumC0523pl, asLong2, asInteger2 != null ? EnumC0721xb.a(asInteger2.intValue()) : null, contentValues.getAsLong("global_number"), contentValues.getAsLong("time"), this.a.toModel(contentValues.getAsByteArray("event_description")));
    }
}
