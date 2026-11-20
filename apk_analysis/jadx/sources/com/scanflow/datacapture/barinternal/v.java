package com.scanflow.datacapture.barinternal;

import android.content.Context;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.PointF;
import android.graphics.RectF;
import android.util.Pair;
import android.util.TypedValue;
import androidx.core.view.InputDeviceCompat;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class v {
    public static final int[] e = {-16776961, -65536, -16711936, InputDeviceCompat.SOURCE_ANY, -16711681, -65281, -1, Color.parseColor("#55FF55"), Color.parseColor("#FFA500"), Color.parseColor("#FF8888"), Color.parseColor("#AAAAFF"), Color.parseColor("#FFFFAA"), Color.parseColor("#55AAAA"), Color.parseColor("#AA33AA"), Color.parseColor("#0D0068")};
    public final LinkedList a;
    public final LinkedList b;
    public final LinkedList c;
    public final Paint d;

    public v(Context context) {
        Intrinsics.checkNotNullParameter(context, "context");
        this.a = new LinkedList();
        this.b = new LinkedList();
        this.c = new LinkedList();
        this.d = new Paint();
        for (int i : e) {
            this.b.add(Integer.valueOf(i));
        }
        this.d.setColor(-65536);
        this.d.setStyle(Paint.Style.STROKE);
        this.d.setStrokeWidth(8.0f);
        this.d.setStrokeCap(Paint.Cap.ROUND);
        this.d.setStrokeJoin(Paint.Join.ROUND);
        this.d.setStrokeMiter(100.0f);
        new C0088f(TypedValue.applyDimension(1, 18.0f, context.getResources().getDisplayMetrics()));
    }

    public final synchronized void a(List results) {
        try {
            Intrinsics.checkNotNullParameter(results, "results");
            LinkedList<Pair> linkedList = new LinkedList();
            this.a.clear();
            Matrix matrix = new Matrix(null);
            Iterator it = results.iterator();
            while (it.hasNext()) {
                C0084b c0084b = (C0084b) it.next();
                if (c0084b.d != null) {
                    RectF rectF = new RectF(c0084b.d);
                    RectF rectF2 = new RectF();
                    matrix.mapRect(rectF2, rectF);
                    this.a.add(new Pair(Float.valueOf(c0084b.c), rectF2));
                    if (rectF.width() >= 16.0f && rectF.height() >= 16.0f) {
                        linkedList.add(new Pair(Float.valueOf(c0084b.c), c0084b));
                    }
                }
            }
            this.c.clear();
            if (!linkedList.isEmpty()) {
                for (Pair pair : linkedList) {
                    u uVar = new u();
                    ((Number) pair.first).floatValue();
                    new RectF(((C0084b) pair.second).d);
                    PointF pointF = ((C0084b) pair.second).e;
                    this.c.add(uVar);
                    if (this.c.size() >= e.length) {
                        break;
                    }
                }
            }
        } catch (Throwable th) {
            throw th;
        }
    }
}
