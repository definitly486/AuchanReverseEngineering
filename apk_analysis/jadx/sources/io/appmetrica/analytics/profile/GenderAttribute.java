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

/* JADX INFO: loaded from: classes3.dex */
public class GenderAttribute {
    private final L6 a = new L6("appmetrica_gender", new C0614t8(), new Pl());

    public enum Gender {
        MALE("M"),
        FEMALE("F"),
        OTHER("O");

        private final String a;

        Gender(String str) {
            this.a = str;
        }

        public String getStringValue() {
            return this.a;
        }
    }

    GenderAttribute() {
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValue(Gender gender) {
        String str = this.a.c;
        String stringValue = gender.getStringValue();
        C0588s8 c0588s8 = new C0588s8();
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new C0525pn(str, stringValue, c0588s8, l6.a, new J4(l6.b)));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueIfUndefined(Gender gender) {
        String str = this.a.c;
        String stringValue = gender.getStringValue();
        C0588s8 c0588s8 = new C0588s8();
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new C0525pn(str, stringValue, c0588s8, l6.a, new C0575rl(l6.b)));
    }

    public UserProfileUpdate<? extends InterfaceC0708wo> withValueReset() {
        L6 l6 = this.a;
        return new UserProfileUpdate<>(new Oi(0, l6.c, l6.a, l6.b));
    }
}
