package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import io.appmetrica.analytics.coreapi.internal.db.DatabaseScript;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import io.appmetrica.analytics.modulesapi.internal.common.TableDescription;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleServicesDatabase;
import java.io.File;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class Pk {
    public final C0561r7 a;
    public C0509p7 b;
    public C0246f3 c;
    public C0272g3 d;
    public Ob e;
    public Pb f;
    public Jn g;
    public Kn h;
    public final LinkedHashMap i = new LinkedHashMap();
    public final LinkedHashMap j = new LinkedHashMap();
    public final LinkedHashMap k = new LinkedHashMap();

    public Pk(File file) {
        this.a = new C0561r7(file);
    }

    public final IBinaryDataHelper a(Context context) {
        C0246f3 c0246f3 = this.c;
        if (c0246f3 != null) {
            return c0246f3;
        }
        C0246f3 c0246f4 = new C0246f3(new Kl(f(context)), "binary_data");
        this.c = c0246f4;
        return c0246f4;
    }

    public final synchronized IBinaryDataHelper b(Context context) {
        C0272g3 c0272g3;
        c0272g3 = this.d;
        if (c0272g3 == null) {
            c0272g3 = new C0272g3(a(context));
            this.d = c0272g3;
        }
        return c0272g3;
    }

    public final synchronized IBinaryDataHelper c(Context context) {
        return a(context);
    }

    public final synchronized InterfaceC0280gb d(Context context) {
        Pb pb;
        try {
            pb = this.f;
            if (pb == null) {
                Ob ob = this.e;
                if (ob == null) {
                    ob = new Ob("preferences", new Kl(f(context)), Ka.I.d.e());
                    this.e = ob;
                }
                pb = new Pb(ob);
                this.f = pb;
            }
        } catch (Throwable th) {
            throw th;
        }
        return pb;
    }

    public final synchronized InterfaceC0280gb e(Context context) {
        Ob ob;
        ob = this.e;
        if (ob == null) {
            ob = new Ob("preferences", new Kl(f(context)), Ka.I.d.e());
            this.e = ob;
        }
        return ob;
    }

    public final synchronized C0509p7 f(Context context) {
        C0509p7 c0509p7;
        try {
            c0509p7 = this.b;
            if (c0509p7 == null) {
                C0561r7 c0561r7 = this.a;
                String strA = new C0536q7(c0561r7.a, c0561r7.b, true).a(context, new C0704wk());
                C0199d7 c0199d7 = M5.c;
                c0199d7.getClass();
                HashMap map = new HashMap();
                map.put("preferences", J5.a);
                map.put("binary_data", H5.a);
                map.put("temp_cache", Nn.a);
                Iterator<ModuleServicesDatabase> it = Ka.I.p().a().iterator();
                while (it.hasNext()) {
                    for (TableDescription tableDescription : it.next().getTables()) {
                        map.put(tableDescription.getTableName(), tableDescription.getColumnNames());
                    }
                }
                C0733xn c0733xn = c0199d7.c;
                C0457n7 c0457n7 = c0199d7.a;
                C0405l7 c0405l7 = c0457n7.e;
                C0431m7 c0431m7 = c0457n7.f;
                Pa pa = new Pa(false);
                pa.a(114, new C0730xk());
                Iterator<ModuleServicesDatabase> it2 = Ka.I.p().a().iterator();
                while (it2.hasNext()) {
                    Iterator<TableDescription> it3 = it2.next().getTables().iterator();
                    while (it3.hasNext()) {
                        for (Map.Entry<Integer, DatabaseScript> entry : it3.next().getDatabaseProviderUpgradeScript().entrySet()) {
                            pa.a(entry.getKey(), entry.getValue());
                        }
                    }
                }
                An an = new An("service database", map);
                c0733xn.getClass();
                c0509p7 = new C0509p7(context, strA, new C0759yn(c0405l7, c0431m7, pa, an), PublicLogger.getAnonymousInstance());
                this.b = c0509p7;
            }
        } catch (Throwable th) {
            throw th;
        }
        return c0509p7;
    }

    public final synchronized C0509p7 c(Context context, C0274g5 c0274g5) {
        Object c0509p7;
        try {
            String str = new X4(c0274g5).a;
            LinkedHashMap linkedHashMap = this.i;
            c0509p7 = linkedHashMap.get(str);
            if (c0509p7 == null) {
                C0561r7 c0561r7 = this.a;
                String strA = new C0536q7(c0561r7.a, c0561r7.b, false).a(context, new X4(c0274g5));
                C0199d7 c0199d7 = M5.c;
                c0199d7.getClass();
                String str2 = c0274g5.b;
                if (str2 == null) {
                    str2 = "main";
                }
                String str3 = String.format("component-%s", str2);
                C0733xn c0733xn = c0199d7.c;
                C0457n7 c0457n7 = c0199d7.a;
                C0250f7 c0250f7 = c0457n7.a;
                C0276g7 c0276g7 = c0457n7.b;
                Pa pa = new Pa(false);
                pa.a(112, new C0119a5());
                An an = new An(str3, c0199d7.b.a);
                c0733xn.getClass();
                c0509p7 = new C0509p7(context, strA, new C0759yn(c0250f7, c0276g7, pa, an), PublicLogger.getAnonymousInstance());
                linkedHashMap.put(str, c0509p7);
            }
        } catch (Throwable th) {
            throw th;
        }
        return (C0509p7) c0509p7;
    }

    public final synchronized IBinaryDataHelper a(Context context, C0274g5 c0274g5) {
        Object c0246f3;
        try {
            String str = new X4(c0274g5).a;
            LinkedHashMap linkedHashMap = this.k;
            c0246f3 = linkedHashMap.get(str);
            if (c0246f3 == null) {
                c0246f3 = new C0246f3(new Kl(c(context, c0274g5)), "binary_data");
                linkedHashMap.put(str, c0246f3);
            }
        } catch (Throwable th) {
            throw th;
        }
        return (IBinaryDataHelper) c0246f3;
    }

    public final synchronized InterfaceC0280gb b(Context context, C0274g5 c0274g5) {
        Object ob;
        try {
            String str = new X4(c0274g5).a;
            LinkedHashMap linkedHashMap = this.j;
            ob = linkedHashMap.get(str);
            if (ob == null) {
                ob = new Ob("preferences", new Kl(c(context, c0274g5)), Ka.I.d.e());
                linkedHashMap.put(str, ob);
            }
        } catch (Throwable th) {
            throw th;
        }
        return (InterfaceC0280gb) ob;
    }
}
