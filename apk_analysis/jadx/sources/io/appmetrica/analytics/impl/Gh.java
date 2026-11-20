package io.appmetrica.analytics.impl;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.DatabaseUtils;
import android.database.sqlite.SQLiteDatabase;
import android.text.TextUtils;
import androidx.core.location.LocationRequestCompat;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.IntIterator;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import com.scanflow.datacapture.barinternal.kotlin.ranges.IntRange;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import io.appmetrica.analytics.coreutils.internal.ApiKeyUtils;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.coreutils.internal.WrapUtils;
import io.appmetrica.analytics.coreutils.internal.db.DBUtils;
import io.appmetrica.analytics.coreutils.internal.io.GZIPCompressor;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.networktasks.internal.DefaultNetworkResponseHandler;
import io.appmetrica.analytics.networktasks.internal.FullUrlFormer;
import io.appmetrica.analytics.networktasks.internal.RequestBodyEncrypter;
import io.appmetrica.analytics.networktasks.internal.RequestDataHolder;
import io.appmetrica.analytics.networktasks.internal.ResponseDataHolder;
import io.appmetrica.analytics.networktasks.internal.RetryPolicyConfig;
import io.appmetrica.analytics.networktasks.internal.SendingDataTaskHelper;
import io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask;
import io.appmetrica.analytics.protobuf.nano.CodedOutputByteBufferNano;
import io.appmetrica.analytics.protobuf.nano.MessageNano;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import javax.net.ssl.SSLSocketFactory;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Gh implements UnderlyingNetworkTask {
    public final C0455n5 a;
    public C7 c;
    public final Hh d;
    public Pf e;
    public final C0415lh f;
    public final PublicLogger g;
    public final C0441mh h;
    public final FullUrlFormer i;
    public final Ub j;
    public final RequestDataHolder k;
    public final ResponseDataHolder l;
    public final SendingDataTaskHelper m;
    public int n;
    public final LinkedHashMap b = new LinkedHashMap();
    public boolean o = false;

    public Gh(C0455n5 c0455n5, C0441mh c0441mh, Ub ub, FullUrlFormer<C0727xh> fullUrlFormer, RequestDataHolder requestDataHolder, ResponseDataHolder responseDataHolder, RequestBodyEncrypter requestBodyEncrypter) {
        this.m = new SendingDataTaskHelper(requestBodyEncrypter, new GZIPCompressor(), requestDataHolder, responseDataHolder, new DefaultNetworkResponseHandler());
        this.h = c0441mh;
        this.a = c0455n5;
        Hh hh = new Hh(c0455n5);
        this.d = hh;
        PublicLogger publicLoggerP = c0455n5.p();
        this.g = publicLoggerP;
        this.j = ub;
        this.k = requestDataHolder;
        this.l = responseDataHolder;
        this.i = fullUrlFormer;
        this.f = new C0415lh(hh, new C0505p3(1024000, "event value in ReportTask", publicLoggerP), AbstractC0763z1.a(), Ka.k().C());
    }

    public final void a(boolean z) {
        Hh hh = this.d;
        Pf pf = this.e;
        A9[] a9Arr = pf.a.a;
        List list = pf.b;
        int i = this.n;
        Po po = hh.c;
        synchronized (po) {
            JSONObject jSONObjectA = po.a.a();
            if (jSONObjectA.optInt("report_request_id", -1) != i) {
                po.a.a(jSONObjectA.put("report_request_id", i));
            }
            Qo qo = po.a;
            Qo.a(qo.a);
            Qo.a(qo.b);
        }
        ArrayList arrayList = new ArrayList(a9Arr.length);
        int length = a9Arr.length;
        char c = 0;
        int i2 = 0;
        int i3 = 0;
        while (true) {
            Long l = null;
            if (i2 >= length) {
                break;
            }
            A9 a9 = a9Arr[i2];
            int i4 = i3 + 1;
            long jLongValue = ((Number) list.get(i3)).longValue();
            EnumC0523pl enumC0523pl = (EnumC0523pl) AbstractC0388kg.b.get(a9.b.c);
            if (enumC0523pl == null) {
                enumC0523pl = EnumC0523pl.FOREGROUND;
            }
            C0745y9[] c0745y9Arr = a9.c;
            if (c0745y9Arr.length != 0) {
                Long lValueOf = Long.valueOf(c0745y9Arr[c].a);
                IntIterator it = new IntRange(1, ArraysKt.getLastIndex(c0745y9Arr)).iterator();
                l = lValueOf;
                while (it.hasNext()) {
                    list = list;
                    Long lValueOf2 = Long.valueOf(c0745y9Arr[it.nextInt()].a);
                    if (l.compareTo(lValueOf2) < 0) {
                        l = lValueOf2;
                    }
                }
            }
            List list2 = list;
            long jLongValue2 = l != null ? l.longValue() : 0L;
            C0745y9[] c0745y9Arr2 = a9.c;
            if (c0745y9Arr2 != null) {
                for (C0745y9 c0745y9 : c0745y9Arr2) {
                }
            }
            arrayList.add(new Zk(jLongValue, enumC0523pl.a, jLongValue2, z));
            i2++;
            list = list2;
            i3 = i4;
            c = 0;
        }
        C0173c7 c0173c7 = hh.a;
        long jA = hh.b.a();
        c0173c7.getClass();
        ArrayList arrayList2 = new ArrayList();
        String str = String.format(Locale.US, "%1$s = ? AND %2$s = ? AND %3$s <= ?", "session_id", "session_type", "number_in_session");
        c0173c7.b.lock();
        try {
            SQLiteDatabase writableDatabase = c0173c7.c.getWritableDatabase();
            if (writableDatabase != null) {
                if (M5.a.booleanValue()) {
                    c0173c7.c();
                }
                writableDatabase.beginTransaction();
                try {
                    int size = arrayList.size();
                    int i5 = 0;
                    while (i5 < size) {
                        Object obj = arrayList.get(i5);
                        i5++;
                        arrayList2.add(c0173c7.a(writableDatabase, str, (Zk) obj));
                    }
                    writableDatabase.delete("sessions", K5.c, new String[]{String.valueOf(jA)});
                    writableDatabase.setTransactionSuccessful();
                    writableDatabase.endTransaction();
                } catch (Throwable th) {
                    writableDatabase.endTransaction();
                    throw th;
                }
            }
        } catch (Throwable unused) {
        }
        c0173c7.b.unlock();
        int size2 = arrayList2.size();
        int i6 = 0;
        int i7 = 0;
        while (i7 < size2) {
            Object obj2 = arrayList2.get(i7);
            i7++;
            X6 x6 = (X6) obj2;
            if (x6.a != null) {
                ArrayList arrayList3 = new ArrayList();
                Iterator it2 = x6.a.iterator();
                while (it2.hasNext()) {
                    Integer asInteger = ((ContentValues) it2.next()).getAsInteger("type");
                    asInteger.intValue();
                    arrayList3.add(asInteger);
                }
                ArrayList arrayList4 = c0173c7.g;
                int size3 = arrayList4.size();
                int i8 = 0;
                while (i8 < size3) {
                    Object obj3 = arrayList4.get(i8);
                    i8++;
                    ((InterfaceC0433m9) obj3).b(arrayList3);
                }
                List list3 = x6.a;
                for (int i9 = 0; i9 < list3.size(); i9++) {
                    ContentValues contentValues = (ContentValues) list3.get(i9);
                    Integer asInteger2 = contentValues.getAsInteger("type");
                    if (Q9.d.contains(EnumC0721xb.a(asInteger2 != null ? asInteger2.intValue() : -1))) {
                        C0665v7 model = new C0691w7(null, 1, null).toModel(contentValues);
                        PublicLogger publicLogger = c0173c7.e.m;
                        EnumC0721xb enumC0721xb = model.d;
                        C0639u7 c0639u7 = model.g;
                        publicLogger.info(AbstractC0414lg.a("Event removed from db", enumC0721xb, c0639u7.b, c0639u7.c), new Object[0]);
                    }
                }
            }
            i6 += x6.b;
        }
        c0173c7.f.addAndGet(-i6);
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final String description() {
        return "ReportTask_" + ApiKeyUtils.createPartialApiKey(this.a.b.b);
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final FullUrlFormer<?> getFullUrlFormer() {
        return this.i;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final RequestDataHolder getRequestDataHolder() {
        return this.k;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final ResponseDataHolder getResponseDataHolder() {
        return this.l;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final RetryPolicyConfig getRetryPolicyConfig() {
        return ((C0727xh) this.a.k.a()).getRetryPolicyConfig();
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final SSLSocketFactory getSslSocketFactory() {
        ((Rl) Ka.I.z()).getClass();
        return null;
    }

    /* JADX WARN: Code duplicated, block: B:101:0x02af  */
    /* JADX WARN: Code duplicated, block: B:102:0x02b6  */
    /* JADX WARN: Code duplicated, block: B:107:0x02d5 A[Catch: all -> 0x02de, TryCatch #14 {all -> 0x02de, blocks: (B:105:0x02c1, B:107:0x02d5, B:110:0x02e2), top: B:228:0x02c1 }] */
    /* JADX WARN: Code duplicated, block: B:126:0x031b  */
    /* JADX WARN: Code duplicated, block: B:128:0x0328  */
    /* JADX WARN: Code duplicated, block: B:130:0x0341  */
    /* JADX WARN: Code duplicated, block: B:144:0x03b6  */
    /* JADX WARN: Code duplicated, block: B:145:0x03b9  */
    /* JADX WARN: Code duplicated, block: B:152:0x03cb  */
    /* JADX WARN: Code duplicated, block: B:156:0x03d2  */
    /* JADX WARN: Code duplicated, block: B:162:0x03f4  */
    /* JADX WARN: Code duplicated, block: B:164:0x03fa  */
    /* JADX WARN: Code duplicated, block: B:170:0x0442  */
    /* JADX WARN: Code duplicated, block: B:171:0x0446  */
    /* JADX WARN: Code duplicated, block: B:174:0x0455  */
    /* JADX WARN: Code duplicated, block: B:180:0x0492 A[LOOP:5: B:179:0x0490->B:180:0x0492, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:184:0x04b0 A[RETURN] */
    /* JADX WARN: Code duplicated, block: B:186:0x04b3  */
    /* JADX WARN: Code duplicated, block: B:208:0x042b A[EXC_TOP_SPLITTER, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:228:0x02c1 A[EXC_TOP_SPLITTER, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:246:0x0392 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:247:0x03e6 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:248:0x03e1 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:249:0x037d A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:251:0x03ee A[EDGE_INSN: B:251:0x03ee->B:160:0x03ee BREAK  A[LOOP:4: B:124:0x0315->B:252:0x0315], SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:260:0x02e2 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:264:0x024e A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:82:0x01e6 A[LOOP:3: B:80:0x01e0->B:82:0x01e6, LOOP_END] */
    /* JADX WARN: Code duplicated, block: B:85:0x0215  */
    /* JADX WARN: Code duplicated, block: B:86:0x0218  */
    /* JADX WARN: Code duplicated, block: B:89:0x0225 A[Catch: all -> 0x02a7, TryCatch #2 {all -> 0x02a7, blocks: (B:87:0x021d, B:89:0x0225, B:90:0x023b, B:92:0x0241, B:94:0x0249, B:95:0x024e, B:96:0x028e), top: B:206:0x021d }] */
    /* JADX WARN: Code duplicated, block: B:92:0x0241 A[Catch: all -> 0x02a7, TryCatch #2 {all -> 0x02a7, blocks: (B:87:0x021d, B:89:0x0225, B:90:0x023b, B:92:0x0241, B:94:0x0249, B:95:0x024e, B:96:0x028e), top: B:206:0x021d }] */
    /* JADX WARN: Code duplicated, block: B:94:0x0249 A[Catch: all -> 0x02a7, TryCatch #2 {all -> 0x02a7, blocks: (B:87:0x021d, B:89:0x0225, B:90:0x023b, B:92:0x0241, B:94:0x0249, B:95:0x024e, B:96:0x028e), top: B:206:0x021d }] */
    /* JADX WARN: Code duplicated, block: B:98:0x02a7 A[PHI: r7
      0x02a7: PHI (r7v4 ??) = (r7v3 ??), (r7v2 ??) binds: [B:200:0x02a7, B:88:0x0223] A[DONT_GENERATE, DONT_INLINE]] */
    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r13v1 */
    /* JADX WARN: Type inference failed for: r13v10 */
    /* JADX WARN: Type inference failed for: r13v2, types: [java.lang.Integer] */
    /* JADX WARN: Type inference failed for: r13v8 */
    /* JADX WARN: Type inference failed for: r13v9 */
    /* JADX WARN: Type inference failed for: r17v0 */
    /* JADX WARN: Type inference failed for: r17v1, types: [int] */
    /* JADX WARN: Type inference failed for: r17v10 */
    /* JADX WARN: Type inference failed for: r17v11 */
    /* JADX WARN: Type inference failed for: r17v12 */
    /* JADX WARN: Type inference failed for: r17v2 */
    /* JADX WARN: Type inference failed for: r17v7 */
    /* JADX WARN: Type inference failed for: r17v8 */
    /* JADX WARN: Type inference failed for: r17v9 */
    /* JADX WARN: Type inference failed for: r20v0, types: [android.database.sqlite.SQLiteDatabase] */
    /* JADX WARN: Type inference failed for: r21v2 */
    /* JADX WARN: Type inference failed for: r21v3 */
    /* JADX WARN: Type inference failed for: r21v4 */
    /* JADX WARN: Type inference failed for: r21v5 */
    /* JADX WARN: Type inference failed for: r21v6 */
    /* JADX WARN: Type inference failed for: r21v7 */
    /* JADX WARN: Type inference failed for: r21v8 */
    /* JADX WARN: Type inference failed for: r25v1 */
    /* JADX WARN: Type inference failed for: r26v2 */
    /* JADX WARN: Type inference failed for: r2v10, types: [java.lang.Object] */
    /* JADX WARN: Type inference failed for: r2v15 */
    /* JADX WARN: Type inference failed for: r2v16, types: [io.appmetrica.analytics.impl.k0] */
    /* JADX WARN: Type inference failed for: r2v33, types: [java.util.Map] */
    /* JADX WARN: Type inference failed for: r2v9 */
    /* JADX WARN: Type inference failed for: r3v12 */
    /* JADX WARN: Type inference failed for: r3v13, types: [io.appmetrica.analytics.impl.Pf] */
    /* JADX WARN: Type inference failed for: r3v14 */
    /* JADX WARN: Type inference failed for: r3v35 */
    /* JADX WARN: Type inference failed for: r3v36 */
    /* JADX WARN: Type inference failed for: r3v8, types: [io.appmetrica.analytics.impl.s9[]] */
    /* JADX WARN: Type inference failed for: r7v0 */
    /* JADX WARN: Type inference failed for: r7v1 */
    /* JADX WARN: Type inference failed for: r7v10 */
    /* JADX WARN: Type inference failed for: r7v11 */
    /* JADX WARN: Type inference failed for: r7v12 */
    /* JADX WARN: Type inference failed for: r7v13 */
    /* JADX WARN: Type inference failed for: r7v14 */
    /* JADX WARN: Type inference failed for: r7v15 */
    /* JADX WARN: Type inference failed for: r7v16 */
    /* JADX WARN: Type inference failed for: r7v19 */
    /* JADX WARN: Type inference failed for: r7v2 */
    /* JADX WARN: Type inference failed for: r7v20 */
    /* JADX WARN: Type inference failed for: r7v21 */
    /* JADX WARN: Type inference failed for: r7v3 */
    /* JADX WARN: Type inference failed for: r7v30 */
    /* JADX WARN: Type inference failed for: r7v34 */
    /* JADX WARN: Type inference failed for: r7v35 */
    /* JADX WARN: Type inference failed for: r7v36 */
    /* JADX WARN: Type inference failed for: r7v37 */
    /* JADX WARN: Type inference failed for: r7v39, types: [io.appmetrica.analytics.impl.pl, java.lang.Object] */
    /* JADX WARN: Type inference failed for: r7v4 */
    /* JADX WARN: Type inference failed for: r7v40 */
    /* JADX WARN: Type inference failed for: r7v43 */
    /* JADX WARN: Type inference failed for: r7v44 */
    /* JADX WARN: Type inference failed for: r7v45 */
    /* JADX WARN: Type inference failed for: r7v46 */
    /* JADX WARN: Type inference failed for: r7v47 */
    /* JADX WARN: Type inference failed for: r7v48 */
    /* JADX WARN: Type inference failed for: r7v49 */
    /* JADX WARN: Type inference failed for: r7v5 */
    /* JADX WARN: Type inference failed for: r7v50 */
    /* JADX WARN: Type inference failed for: r7v51 */
    /* JADX WARN: Type inference failed for: r7v52 */
    /* JADX WARN: Type inference failed for: r7v53 */
    /* JADX WARN: Type inference failed for: r7v54 */
    /* JADX WARN: Type inference failed for: r7v55 */
    /* JADX WARN: Type inference failed for: r7v8, types: [java.lang.String[]] */
    /* JADX WARN: Type inference failed for: r7v9 */
    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final boolean onCreateTask() {
        Cursor cursorRawQuery;
        ?? r17;
        int iComputeUInt64Size;
        ?? r18;
        ?? r7;
        LinkedHashMap linkedHashMap;
        ?? r8;
        C0173c7 c0173c7;
        Cursor cursorQuery;
        ?? r9;
        ?? readableDatabase;
        StringBuilder sb;
        int i;
        ?? r10;
        LinkedHashMap linkedHashMap2;
        ?? r11;
        Throwable th;
        Map mapEmptyMap;
        Long asLong;
        Object arrayList;
        ?? r12;
        ArrayList arrayList2;
        ArrayList arrayList3;
        Iterator it;
        int i2;
        ?? r2;
        int i3;
        JSONObject jSONObject;
        ?? r13;
        JSONObject jSONObject2;
        ?? r21;
        En en;
        C0363jh c0363jh;
        int length;
        ArrayList arrayList4;
        Iterator<String> itKeys;
        int i4;
        ?? r3;
        String[] strArr;
        int length2;
        byte[][] bArr;
        int i5;
        ?? pf;
        Eh eh;
        C0445ml c0445ml;
        List listEmptyList;
        int i6;
        int i7;
        ?? r25;
        Si siA;
        Integer num;
        C0372k0 c0372k0;
        String str;
        C0173c7 c0173c8 = this.d.a;
        c0173c8.getClass();
        ArrayList arrayList5 = new ArrayList();
        c0173c8.a.lock();
        try {
            SQLiteDatabase readableDatabase2 = c0173c8.c.getReadableDatabase();
            if (readableDatabase2 != null) {
                cursorRawQuery = readableDatabase2.rawQuery(K5.b, null);
                while (cursorRawQuery.moveToNext()) {
                    try {
                        ContentValues contentValues = new ContentValues();
                        DatabaseUtils.cursorRowToContentValues(cursorRawQuery, contentValues);
                        arrayList5.add(contentValues);
                    } catch (Throwable unused) {
                        try {
                            arrayList5 = new ArrayList();
                            Do.a(cursorRawQuery);
                            c0173c8.a.unlock();
                        } catch (Throwable th2) {
                            Do.a(cursorRawQuery);
                            c0173c8.a.unlock();
                            throw th2;
                        }
                    }
                }
            } else {
                cursorRawQuery = null;
            }
            Do.a(cursorRawQuery);
            c0173c8.a.unlock();
        } catch (Throwable unused2) {
            cursorRawQuery = null;
        }
        ContentValues contentValues2 = (ContentValues) CollectionsKt.firstOrNull((List) arrayList5);
        if (contentValues2 == null) {
            return false;
        }
        this.b.clear();
        for (Map.Entry<String, Object> entry : contentValues2.valueSet()) {
            this.b.put(entry.getKey(), entry.getValue().toString());
        }
        String asString = contentValues2.getAsString("report_request_parameters");
        if (TextUtils.isEmpty(asString)) {
            C7 c7 = new C7();
            this.c = c7;
            this.h.c = c7;
        } else {
            try {
                C7 c8 = new C7(new Bb(asString));
                this.c = c8;
                this.h.c = c8;
            } catch (Throwable unused3) {
                C7 c9 = new C7();
                this.c = c9;
                this.h.c = c9;
            }
        }
        C0727xh config = this.j.getConfig();
        List list = config.w;
        if (Do.a((Collection) list)) {
            return false;
        }
        this.i.setHosts(config.q);
        if (!config.u() || Do.a((Collection) this.i.getAllHosts())) {
            this.o = true;
            return false;
        }
        C7 c10 = this.c;
        if (c10 == null) {
            c10 = new C7();
        }
        C7 c11 = c10;
        C0415lh c0415lh = this.f;
        LinkedHashMap linkedHashMap3 = this.b;
        Fh fh = c0415lh.b;
        fh.getClass();
        ArrayList arrayList6 = new ArrayList();
        int i8 = 2;
        ?? r14 = 100;
        r14 = 100;
        try {
            Iterator it2 = fh.a.a(linkedHashMap3).iterator();
            iComputeUInt64Size = 0;
            while (true) {
                try {
                    if (it2.hasNext()) {
                        J7 j7 = (J7) it2.next();
                        if (arrayList6.size() < r14) {
                            Long l = j7.a;
                            if (l != null) {
                                I7 i9 = j7.d;
                                r17 = r14;
                                try {
                                    C9 c9A = AbstractC0388kg.a(i9.a, i9.b, i9.c);
                                    String locale = config.getLocale();
                                    r14 = j7.b;
                                    C0771z9 c0771z9 = new C0771z9();
                                    c0771z9.a = c9A;
                                    c0771z9.b = locale;
                                    if (r14 != 0) {
                                        Integer num2 = (Integer) AbstractC0388kg.a.get(r14);
                                        c0771z9.c = num2 != null ? num2.intValue() : 0;
                                    }
                                    iComputeUInt64Size = iComputeUInt64Size + CodedOutputByteBufferNano.computeUInt64Size(1, LocationRequestCompat.PASSIVE_INTERVAL) + CodedOutputByteBufferNano.computeMessageSize(i8, c0771z9);
                                    if (iComputeUInt64Size >= 250880) {
                                        r7 = r14;
                                        r18 = r17;
                                        break;
                                    }
                                    EnumC0523pl enumC0523pl = (EnumC0523pl) AbstractC0388kg.b.get(c0771z9.c);
                                    if (enumC0523pl == null) {
                                        enumC0523pl = EnumC0523pl.FOREGROUND;
                                    }
                                    int i10 = i8;
                                    try {
                                        arrayList6.add(new Eh(l.longValue(), c0771z9, enumC0523pl.a));
                                        r14 = r17;
                                        i8 = i10;
                                    } catch (Throwable th3) {
                                        th = th3;
                                        fh.b.reportError("protobuf_serialization_error", th);
                                        r7 = r14;
                                        r18 = r17;
                                        Pair pair = new Pair(arrayList6, Integer.valueOf(iComputeUInt64Size));
                                        List<Eh> list2 = (List) pair.component1();
                                        int iIntValue = ((Number) pair.component2()).intValue();
                                        linkedHashMap = new LinkedHashMap(RangesKt.coerceAtLeast(MapsKt.mapCapacity(CollectionsKt.collectionSizeOrDefault(list2, 10)), 16));
                                        r8 = r7;
                                        for (Eh eh2 : list2) {
                                            Pair pair2 = TuplesKt.to(Long.valueOf(eh2.a), Integer.valueOf(eh2.c));
                                            Object first = pair2.getFirst();
                                            linkedHashMap.put(first, pair2.getSecond());
                                            r8 = first;
                                        }
                                        c0173c7 = fh.a.a;
                                        c0173c7.getClass();
                                        if (linkedHashMap.isEmpty()) {
                                            cursorQuery = null;
                                        } else {
                                            c0173c7.a.lock();
                                            try {
                                                readableDatabase = c0173c7.c.getReadableDatabase();
                                                if (readableDatabase != 0) {
                                                    sb = new StringBuilder();
                                                    r8 = new String[linkedHashMap.size() * 2];
                                                    i = 0;
                                                    for (Map.Entry entry2 : linkedHashMap.entrySet()) {
                                                        if (i > 0) {
                                                            sb.append(" OR ");
                                                        }
                                                        sb.append("(");
                                                        sb.append("session_id");
                                                        sb.append(" = ? AND ");
                                                        sb.append("session_type");
                                                        sb.append(" = ?)");
                                                        int i11 = i * 2;
                                                        r8[i11] = Long.toString(((Long) entry2.getKey()).longValue());
                                                        r8[i11 + 1] = Integer.toString(((Integer) entry2.getValue()).intValue());
                                                        i++;
                                                    }
                                                    cursorQuery = readableDatabase.query("events", null, sb.toString(), r8, null, null, "session_id ASC, number_in_session ASC", String.valueOf((int) r18));
                                                    r9 = r8;
                                                } else {
                                                    cursorQuery = null;
                                                    r9 = r8;
                                                }
                                            } catch (Throwable unused4) {
                                            }
                                            c0173c7.a.unlock();
                                            r10 = r9;
                                        }
                                        if (cursorQuery == null) {
                                            r10 = r8;
                                            mapEmptyMap = MapsKt.emptyMap();
                                            r12 = 0;
                                        } else {
                                            r10 = r8;
                                            linkedHashMap2 = new LinkedHashMap();
                                            r11 = r10;
                                            while (cursorQuery.moveToNext()) {
                                                try {
                                                    try {
                                                        try {
                                                            ContentValues contentValues3 = new ContentValues();
                                                            DBUtils.cursorRowToContentValues(cursorQuery, contentValues3);
                                                            asLong = contentValues3.getAsLong("session_id");
                                                            arrayList = linkedHashMap2.get(asLong);
                                                            if (arrayList == null) {
                                                                arrayList = new ArrayList();
                                                                linkedHashMap2.put(asLong, arrayList);
                                                            }
                                                            ((List) arrayList).add(contentValues3);
                                                            r11 = asLong;
                                                        } catch (Throwable th4) {
                                                            th = th4;
                                                            r11 = 0;
                                                            try {
                                                                throw th;
                                                            } catch (Throwable th5) {
                                                                CloseableKt.closeFinally(cursorQuery, th);
                                                                throw th5;
                                                            }
                                                        }
                                                    } catch (Throwable th6) {
                                                        r11 = 0;
                                                        th = th6;
                                                    }
                                                } catch (Throwable unused5) {
                                                }
                                            }
                                            Unit unit = Unit.INSTANCE;
                                            r11 = 0;
                                            CloseableKt.closeFinally(cursorQuery, null);
                                            mapEmptyMap = linkedHashMap2;
                                            r12 = r11;
                                        }
                                        JSONObject jSONObject3 = new JSONObject();
                                        arrayList2 = new ArrayList();
                                        arrayList3 = new ArrayList();
                                        it = list2.iterator();
                                        i2 = iIntValue;
                                        r2 = r12;
                                        i3 = 0;
                                        jSONObject = jSONObject3;
                                        r13 = r2;
                                        while (true) {
                                            if (it.hasNext()) {
                                                jSONObject2 = jSONObject;
                                                eh = (Eh) it.next();
                                                if (i3 < r18) {
                                                    Fh fh2 = fh;
                                                    c0445ml = fh2.c;
                                                    ArrayList arrayList7 = arrayList2;
                                                    fh = fh2;
                                                    long j = eh.a;
                                                    C0771z9 c0771z10 = eh.b;
                                                    listEmptyList = (List) mapEmptyMap.get(Long.valueOf(j));
                                                    if (listEmptyList == null) {
                                                        listEmptyList = CollectionsKt.emptyList();
                                                    }
                                                    int size = arrayList7.size();
                                                    List list3 = listEmptyList;
                                                    C0234eh c0234eh = new C0234eh(i2, i3, r13);
                                                    c0445ml.getClass();
                                                    arrayList3 = arrayList3;
                                                    i6 = i2;
                                                    r21 = 0;
                                                    r12 = 0;
                                                    r21 = 0;
                                                    r18 = 100;
                                                    i7 = i3;
                                                    mapEmptyMap = mapEmptyMap;
                                                    r25 = r13;
                                                    arrayList2 = arrayList7;
                                                    try {
                                                        siA = c0445ml.a(j, c0771z10, list3, config, size, c0234eh);
                                                    } catch (Throwable th7) {
                                                        c0445ml.b.reportError("protobuf_serialization_error", th7);
                                                        siA = null;
                                                    }
                                                    if (siA == null) {
                                                        i2 = i6;
                                                        jSONObject = jSONObject2;
                                                        i3 = i7;
                                                        r13 = r25;
                                                    } else {
                                                        i2 = siA.d;
                                                        i3 = siA.e;
                                                        num = siA.f;
                                                        if (r2 != 0) {
                                                        }
                                                        r2 = siA.b;
                                                        arrayList3.add(Long.valueOf(eh.a));
                                                        arrayList2.add(siA.a);
                                                        c0372k0 = siA.b;
                                                        if (c0372k0 != null) {
                                                            str = c0372k0.a;
                                                        } else {
                                                            str = null;
                                                        }
                                                        if (str != null) {
                                                            jSONObject = jSONObject2;
                                                        } else {
                                                            jSONObject = jSONObject2;
                                                        }
                                                        if (siA.c) {
                                                            break;
                                                        }
                                                        r13 = num;
                                                    }
                                                } else {
                                                    arrayList2 = arrayList2;
                                                    arrayList3 = arrayList3;
                                                    r21 = 0;
                                                }
                                            } else {
                                                jSONObject2 = jSONObject;
                                                arrayList2 = arrayList2;
                                                r21 = r12;
                                                arrayList3 = arrayList3;
                                            }
                                            jSONObject = jSONObject2;
                                            break;
                                        }
                                        if (arrayList2.isEmpty()) {
                                            pf = r21;
                                        } else {
                                            C0389kh c0389kh = c0415lh.c;
                                            c0389kh.getClass();
                                            D9 d9 = new D9();
                                            C0667v9 c0667v9 = new C0667v9();
                                            c0667v9.a = WrapUtils.getOrDefaultIfEmpty(c11.b, config.getUuid());
                                            c0667v9.b = WrapUtils.getOrDefaultIfEmpty(c11.a, config.getDeviceId());
                                            d9.b = c0667v9;
                                            en = c0389kh.a;
                                            c0363jh = new C0363jh(d9);
                                            synchronized (en) {
                                                en.a.a(c0363jh);
                                                d9.a = (A9[]) arrayList2.toArray(new A9[0]);
                                                length = jSONObject.length();
                                                if (length <= 0) {
                                                    r3 = r21;
                                                    i4 = 0;
                                                } else {
                                                    arrayList4 = new ArrayList(length);
                                                    itKeys = jSONObject.keys();
                                                    while (itKeys.hasNext()) {
                                                        String next = itKeys.next();
                                                        C0589s9 c0589s9 = new C0589s9();
                                                        c0589s9.a = next;
                                                        c0589s9.b = jSONObject.getString(next);
                                                        arrayList4.add(c0589s9);
                                                    }
                                                    i4 = 0;
                                                    r3 = (C0589s9[]) arrayList4.toArray(new C0589s9[0]);
                                                }
                                                d9.c = r3;
                                                d9.e = (String[]) list.toArray(new String[i4]);
                                                strArr = (String[]) config.x.toArray(new String[i4]);
                                                length2 = strArr.length;
                                                bArr = new byte[length2][];
                                                for (i5 = 0; i5 < length2; i5++) {
                                                    bArr[i5] = StringUtils.getUTF8Bytes(strArr[i5]);
                                                }
                                                d9.f = bArr;
                                                pf = new Pf(d9, arrayList3, c0415lh.a.a());
                                            }
                                        }
                                        this.e = pf;
                                        if (pf == 0) {
                                            return false;
                                        }
                                        int i12 = pf.c;
                                        this.n = i12;
                                        this.h.e = i12;
                                        this.m.prepareAndSetPostData(MessageNano.toByteArray(pf.a));
                                        return true;
                                    }
                                } catch (Throwable th8) {
                                    th = th8;
                                }
                            }
                        }
                    }
                    r18 = r14;
                    r7 = r14;
                    break;
                } catch (Throwable th9) {
                    th = th9;
                    r17 = r14;
                }
            }
            while (true) {
                if (it.hasNext()) {
                    jSONObject2 = jSONObject;
                    eh = (Eh) it.next();
                    if (i3 < r18) {
                        Fh fh3 = fh;
                        c0445ml = fh3.c;
                        ArrayList arrayList8 = arrayList2;
                        fh = fh3;
                        long j2 = eh.a;
                        C0771z9 c0771z11 = eh.b;
                        listEmptyList = (List) mapEmptyMap.get(Long.valueOf(j2));
                        if (listEmptyList == null) {
                            listEmptyList = CollectionsKt.emptyList();
                        }
                        int size2 = arrayList8.size();
                        List list4 = listEmptyList;
                        C0234eh c0234eh2 = new C0234eh(i2, i3, r13);
                        c0445ml.getClass();
                        arrayList3 = arrayList3;
                        i6 = i2;
                        r21 = 0;
                        r12 = 0;
                        r21 = 0;
                        r18 = 100;
                        i7 = i3;
                        mapEmptyMap = mapEmptyMap;
                        r25 = r13;
                        arrayList2 = arrayList8;
                        siA = c0445ml.a(j2, c0771z11, list4, config, size2, c0234eh2);
                        if (siA == null) {
                            i2 = i6;
                            jSONObject = jSONObject2;
                            i3 = i7;
                            r13 = r25;
                        } else {
                            i2 = siA.d;
                            i3 = siA.e;
                            num = siA.f;
                            if (r2 != 0 || Intrinsics.areEqual((Object) r2, siA.b)) {
                                r2 = siA.b;
                                arrayList3.add(Long.valueOf(eh.a));
                                arrayList2.add(siA.a);
                                c0372k0 = siA.b;
                                if (c0372k0 != null) {
                                    str = c0372k0.a;
                                } else {
                                    str = null;
                                }
                                if (str != null || str.length() == 0) {
                                    jSONObject = jSONObject2;
                                } else {
                                    try {
                                        jSONObject = new JSONObject(str);
                                    } catch (Throwable unused6) {
                                        jSONObject = jSONObject2;
                                    }
                                }
                                if (siA.c) {
                                    break;
                                    break;
                                }
                                r13 = num;
                            }
                        }
                    } else {
                        arrayList2 = arrayList2;
                        arrayList3 = arrayList3;
                        r21 = 0;
                    }
                } else {
                    jSONObject2 = jSONObject;
                    arrayList2 = arrayList2;
                    r21 = r12;
                    arrayList3 = arrayList3;
                }
                jSONObject = jSONObject2;
                break;
            }
        } catch (Throwable th10) {
            th = th10;
            r17 = 100;
            iComputeUInt64Size = 0;
        }
        Pair pair3 = new Pair(arrayList6, Integer.valueOf(iComputeUInt64Size));
        List<Eh> list5 = (List) pair3.component1();
        int iIntValue2 = ((Number) pair3.component2()).intValue();
        linkedHashMap = new LinkedHashMap(RangesKt.coerceAtLeast(MapsKt.mapCapacity(CollectionsKt.collectionSizeOrDefault(list5, 10)), 16));
        r8 = r7;
        while (r0.hasNext()) {
            Pair pair4 = TuplesKt.to(Long.valueOf(eh2.a), Integer.valueOf(eh2.c));
            Object first2 = pair4.getFirst();
            linkedHashMap.put(first2, pair4.getSecond());
            r8 = first2;
        }
        c0173c7 = fh.a.a;
        c0173c7.getClass();
        if (linkedHashMap.isEmpty()) {
            cursorQuery = null;
        } else {
            c0173c7.a.lock();
            readableDatabase = c0173c7.c.getReadableDatabase();
            if (readableDatabase != 0) {
                sb = new StringBuilder();
                r8 = new String[linkedHashMap.size() * 2];
                i = 0;
                while (r5.hasNext()) {
                    if (i > 0) {
                        sb.append(" OR ");
                    }
                    sb.append("(");
                    sb.append("session_id");
                    sb.append(" = ? AND ");
                    sb.append("session_type");
                    sb.append(" = ?)");
                    int i13 = i * 2;
                    r8[i13] = Long.toString(((Long) entry2.getKey()).longValue());
                    r8[i13 + 1] = Integer.toString(((Integer) entry2.getValue()).intValue());
                    i++;
                }
                cursorQuery = readableDatabase.query("events", null, sb.toString(), r8, null, null, "session_id ASC, number_in_session ASC", String.valueOf((int) r18));
                r9 = r8;
            } else {
                cursorQuery = null;
                r9 = r8;
            }
            c0173c7.a.unlock();
            r10 = r9;
        }
        if (cursorQuery == null) {
            r10 = r8;
            mapEmptyMap = MapsKt.emptyMap();
            r12 = 0;
        } else {
            r10 = r8;
            linkedHashMap2 = new LinkedHashMap();
            r11 = r10;
            while (cursorQuery.moveToNext()) {
                ContentValues contentValues4 = new ContentValues();
                DBUtils.cursorRowToContentValues(cursorQuery, contentValues4);
                asLong = contentValues4.getAsLong("session_id");
                arrayList = linkedHashMap2.get(asLong);
                if (arrayList == null) {
                    arrayList = new ArrayList();
                    linkedHashMap2.put(asLong, arrayList);
                }
                ((List) arrayList).add(contentValues4);
                r11 = asLong;
            }
            Unit unit2 = Unit.INSTANCE;
            r11 = 0;
            CloseableKt.closeFinally(cursorQuery, null);
            mapEmptyMap = linkedHashMap2;
            r12 = r11;
        }
        JSONObject jSONObject4 = new JSONObject();
        arrayList2 = new ArrayList();
        arrayList3 = new ArrayList();
        it = list5.iterator();
        i2 = iIntValue2;
        r2 = r12;
        i3 = 0;
        jSONObject = jSONObject4;
        r13 = r2;
        if (arrayList2.isEmpty()) {
            pf = r21;
        } else {
            C0389kh c0389kh2 = c0415lh.c;
            c0389kh2.getClass();
            D9 d10 = new D9();
            C0667v9 c0667v10 = new C0667v9();
            c0667v10.a = WrapUtils.getOrDefaultIfEmpty(c11.b, config.getUuid());
            c0667v10.b = WrapUtils.getOrDefaultIfEmpty(c11.a, config.getDeviceId());
            d10.b = c0667v10;
            en = c0389kh2.a;
            c0363jh = new C0363jh(d10);
            synchronized (en) {
                en.a.a(c0363jh);
            }
            d10.a = (A9[]) arrayList2.toArray(new A9[0]);
            length = jSONObject.length();
            if (length <= 0) {
                r3 = r21;
                i4 = 0;
            } else {
                arrayList4 = new ArrayList(length);
                itKeys = jSONObject.keys();
                while (itKeys.hasNext()) {
                    String next2 = itKeys.next();
                    C0589s9 c0589s10 = new C0589s9();
                    c0589s10.a = next2;
                    c0589s10.b = jSONObject.getString(next2);
                    arrayList4.add(c0589s10);
                }
                i4 = 0;
                r3 = (C0589s9[]) arrayList4.toArray(new C0589s9[0]);
            }
            d10.c = r3;
            d10.e = (String[]) list.toArray(new String[i4]);
            strArr = (String[]) config.x.toArray(new String[i4]);
            length2 = strArr.length;
            bArr = new byte[length2][];
            while (i5 < length2) {
                bArr[i5] = StringUtils.getUTF8Bytes(strArr[i5]);
            }
            d10.f = bArr;
            pf = new Pf(d10, arrayList3, c0415lh.a.a());
        }
        this.e = pf;
        if (pf == 0) {
            return false;
        }
        int i14 = pf.c;
        this.n = i14;
        this.h.e = i14;
        this.m.prepareAndSetPostData(MessageNano.toByteArray(pf.a));
        return true;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onPerformRequest() {
        this.m.onPerformRequest();
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onPostRequestComplete(boolean z) {
        String strA;
        if (z) {
            a(false);
        } else if (this.l.getResponseCode() == 400) {
            a(true);
        }
        if (z) {
            for (A9 a9 : this.e.a.a) {
                for (C0745y9 c0745y9 : a9.c) {
                    if (c0745y9 != null && (strA = AbstractC0414lg.a(c0745y9)) != null) {
                        this.g.info(strA, new Object[0]);
                    }
                }
            }
        }
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final boolean onRequestComplete() {
        return this.m.isResponseValid();
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onRequestError(Throwable th) {
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onShouldNotExecute() {
        this.o = true;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onSuccessfulTaskFinished() {
        this.o = true;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onTaskAdded() {
        ((A5) this.a.p).d.set(false);
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onTaskFinished() {
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onTaskRemoved() {
        ((A5) this.a.p).d.set(true);
        if (this.o) {
            ((A5) this.a.p).f();
        }
    }

    @Override // io.appmetrica.analytics.networktasks.internal.UnderlyingNetworkTask
    public final void onUnsuccessfulTaskFinished() {
    }
}
