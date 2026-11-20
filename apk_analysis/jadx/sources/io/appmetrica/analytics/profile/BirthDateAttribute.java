package io.appmetrica.analytics.profile;

import io.appmetrica.analytics.impl.C0525pn;
import io.appmetrica.analytics.impl.C0575rl;
import io.appmetrica.analytics.impl.C0588s8;
import io.appmetrica.analytics.impl.C0614t8;
import io.appmetrica.analytics.impl.InterfaceC0708wo;
import io.appmetrica.analytics.impl.J4;
import io.appmetrica.analytics.impl.L6;
import io.appmetrica.analytics.impl.Oi;
import io.appmetrica.analytics.impl.Pl;
import io.appmetrica.analytics.impl.W2;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Locale;

/* JADX INFO: loaded from: classes3.dex */
public class BirthDateAttribute {
    private final L6 a = new L6("appmetrica_birth_date", new C0614t8(), new Pl());

    BirthDateAttribute() {
    }

    final UserProfileUpdate a(Calendar calendar, String str, W2 w2) {
        return new UserProfileUpdate(new C0525pn(this.a.c, new SimpleDateFormat(str).format(calendar.getTime()), new C0588s8(), new C0614t8(), w2));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withAge(int i) {
        int i2 = Calendar.getInstance(Locale.US).get(1) - i;
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i2);
        return a(gregorianCalendar, "yyyy", new J4(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withAgeIfUndefined(int i) {
        int i2 = Calendar.getInstance(Locale.US).get(1) - i;
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i2);
        return a(gregorianCalendar, "yyyy", new C0575rl(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDate(Calendar calendar) {
        return a(calendar, "yyyy-MM-dd", new J4(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDateIfUndefined(Calendar calendar) {
        return a(calendar, "yyyy-MM-dd", new C0575rl(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueReset() {
        return new UserProfileUpdate<>(new Oi(0, this.a.c, new C0614t8(), new Pl()));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDate(int i) {
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i);
        return a(gregorianCalendar, "yyyy", new J4(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDateIfUndefined(int i) {
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i);
        return a(gregorianCalendar, "yyyy", new C0575rl(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDate(int i, int i2) {
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i);
        gregorianCalendar.set(2, i2 - 1);
        gregorianCalendar.set(5, 1);
        return a(gregorianCalendar, "yyyy-MM", new J4(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDateIfUndefined(int i, int i2) {
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i);
        gregorianCalendar.set(2, i2 - 1);
        gregorianCalendar.set(5, 1);
        return a(gregorianCalendar, "yyyy-MM", new C0575rl(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDate(int i, int i2, int i3) {
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i);
        gregorianCalendar.set(2, i2 - 1);
        gregorianCalendar.set(5, i3);
        return a(gregorianCalendar, "yyyy-MM-dd", new J4(this.a.b));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withBirthDateIfUndefined(int i, int i2, int i3) {
        GregorianCalendar gregorianCalendar = new GregorianCalendar();
        gregorianCalendar.set(1, i);
        gregorianCalendar.set(2, i2 - 1);
        gregorianCalendar.set(5, i3);
        return a(gregorianCalendar, "yyyy-MM-dd", new C0575rl(this.a.b));
    }
}
