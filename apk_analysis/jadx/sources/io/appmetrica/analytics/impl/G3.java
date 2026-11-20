package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import java.util.HashMap;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class G3 implements O5 {
    @Override // kotlin.jvm.functions.Function1
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final Map<String, String> invoke(ContentValues contentValues) {
        String asString = contentValues.getAsString("clids");
        HashMap mapC = Cb.c(asString);
        if (Wm.a(mapC)) {
            return mapC;
        }
        AbstractC0677vj.a("Passed clids (" + asString + ") are invalid.", new Object[0]);
        return null;
    }
}
