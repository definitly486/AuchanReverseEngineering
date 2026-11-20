package androidx.activity;

import android.content.res.Resources;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: EdgeToEdge.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SystemBarStyle {
    public static final Companion Companion = new Companion(null);
    private final int darkScrim;
    private final Function1 detectDarkMode;
    private final int lightScrim;
    private final int nightMode;

    public /* synthetic */ SystemBarStyle(int i, int i2, int i3, Function1 function1, DefaultConstructorMarker defaultConstructorMarker) {
        this(i, i2, i3, function1);
    }

    public static final SystemBarStyle auto(int i, int i2) {
        return Companion.auto(i, i2);
    }

    public static final SystemBarStyle auto(int i, int i2, Function1<? super Resources, Boolean> function1) {
        return Companion.auto(i, i2, function1);
    }

    public static final SystemBarStyle dark(int i) {
        return Companion.dark(i);
    }

    public static final SystemBarStyle light(int i, int i2) {
        return Companion.light(i, i2);
    }

    private SystemBarStyle(int i, int i2, int i3, Function1 function1) {
        this.lightScrim = i;
        this.darkScrim = i2;
        this.nightMode = i3;
        this.detectDarkMode = function1;
    }

    public final int getNightMode$activity_release() {
        return this.nightMode;
    }

    public final Function1 getDetectDarkMode$activity_release() {
        return this.detectDarkMode;
    }

    /* JADX INFO: compiled from: EdgeToEdge.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        public final SystemBarStyle auto(int i, int i2) {
            return auto$default(this, i, i2, null, 4, null);
        }

        private Companion() {
        }

        public static /* synthetic */ SystemBarStyle auto$default(Companion companion, int i, int i2, Function1 function1, int i3, Object obj) {
            if ((i3 & 4) != 0) {
                function1 = new Function1() { // from class: androidx.activity.SystemBarStyle$Companion$auto$1
                    @Override // kotlin.jvm.functions.Function1
                    public final Boolean invoke(Resources resources) {
                        Intrinsics.checkNotNullParameter(resources, "resources");
                        return Boolean.valueOf((resources.getConfiguration().uiMode & 48) == 32);
                    }
                };
            }
            return companion.auto(i, i2, function1);
        }

        public final SystemBarStyle auto(int i, int i2, Function1 detectDarkMode) {
            Intrinsics.checkNotNullParameter(detectDarkMode, "detectDarkMode");
            return new SystemBarStyle(i, i2, 0, detectDarkMode, null);
        }

        public final SystemBarStyle dark(int i) {
            return new SystemBarStyle(i, i, 2, new Function1() { // from class: androidx.activity.SystemBarStyle$Companion$dark$1
                @Override // kotlin.jvm.functions.Function1
                public final Boolean invoke(Resources resources) {
                    Intrinsics.checkNotNullParameter(resources, "<anonymous parameter 0>");
                    return Boolean.TRUE;
                }
            }, null);
        }

        public final SystemBarStyle light(int i, int i2) {
            return new SystemBarStyle(i, i2, 1, new Function1() { // from class: androidx.activity.SystemBarStyle$Companion$light$1
                @Override // kotlin.jvm.functions.Function1
                public final Boolean invoke(Resources resources) {
                    Intrinsics.checkNotNullParameter(resources, "<anonymous parameter 0>");
                    return Boolean.FALSE;
                }
            }, null);
        }
    }

    public final int getScrim$activity_release(boolean z) {
        return z ? this.darkScrim : this.lightScrim;
    }

    public final int getScrimWithEnforcedContrast$activity_release(boolean z) {
        if (this.nightMode == 0) {
            return 0;
        }
        if (z) {
            return this.darkScrim;
        }
        return this.lightScrim;
    }
}
