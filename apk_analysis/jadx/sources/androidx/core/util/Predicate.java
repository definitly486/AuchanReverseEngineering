package androidx.core.util;

import android.annotation.SuppressLint;
import androidx.core.util.Predicate;
import java.util.Objects;

/* JADX INFO: loaded from: classes.dex */
@SuppressLint({"UnknownNullness"})
public interface Predicate<T> {
    boolean test(T t);

    @SuppressLint({"MissingNullability"})
    default Predicate<T> and(@SuppressLint({"MissingNullability"}) final Predicate<? super T> predicate) {
        Objects.requireNonNull(predicate);
        return new Predicate() { // from class: com.scanflow.datacapture.barinternal.androidx.core.util.Predicate$$ExternalSyntheticLambda3
            @Override // androidx.core.util.Predicate
            public final boolean test(Object obj) {
                return Predicate.m91$r8$lambda$uZUHv8ZmP0g07RaYYSVB43_db0(this.f$0, predicate, obj);
            }
        };
    }

    /* JADX INFO: renamed from: $r8$lambda$uZUHv8ZmP0g07RaYY-SVB43_db0, reason: not valid java name */
    static /* synthetic */ boolean m91$r8$lambda$uZUHv8ZmP0g07RaYYSVB43_db0(Predicate predicate, Predicate predicate2, Object obj) {
        return predicate.test(obj) && predicate2.test(obj);
    }

    /* JADX INFO: renamed from: $r8$lambda$kGvaRCl43ssAEbOtpN3jU-PWlfU, reason: not valid java name */
    static /* synthetic */ boolean m90$r8$lambda$kGvaRCl43ssAEbOtpN3jUPWlfU(Predicate predicate, Object obj) {
        return !predicate.test(obj);
    }

    @SuppressLint({"MissingNullability"})
    default Predicate<T> negate() {
        return new Predicate() { // from class: com.scanflow.datacapture.barinternal.androidx.core.util.Predicate$$ExternalSyntheticLambda4
            @Override // androidx.core.util.Predicate
            public final boolean test(Object obj) {
                return Predicate.m90$r8$lambda$kGvaRCl43ssAEbOtpN3jUPWlfU(this.f$0, obj);
            }
        };
    }

    @SuppressLint({"MissingNullability"})
    default Predicate<T> or(@SuppressLint({"MissingNullability"}) final Predicate<? super T> predicate) {
        Objects.requireNonNull(predicate);
        return new Predicate() { // from class: com.scanflow.datacapture.barinternal.androidx.core.util.Predicate$$ExternalSyntheticLambda0
            @Override // androidx.core.util.Predicate
            public final boolean test(Object obj) {
                return Predicate.m89$r8$lambda$QAdXGRt3EQ4Q2LWWjQ0qP8TkFQ(this.f$0, predicate, obj);
            }
        };
    }

    /* JADX INFO: renamed from: $r8$lambda$QAdXGRt3EQ4Q2LWWjQ0qP8TkF-Q, reason: not valid java name */
    static /* synthetic */ boolean m89$r8$lambda$QAdXGRt3EQ4Q2LWWjQ0qP8TkFQ(Predicate predicate, Predicate predicate2, Object obj) {
        return predicate.test(obj) || predicate2.test(obj);
    }

    @SuppressLint({"MissingNullability"})
    static <T> Predicate<T> isEqual(@SuppressLint({"MissingNullability"}) final Object obj) {
        if (obj == null) {
            return new Predicate() { // from class: com.scanflow.datacapture.barinternal.androidx.core.util.Predicate$$ExternalSyntheticLambda1
                @Override // androidx.core.util.Predicate
                public final boolean test(Object obj2) {
                    return Objects.isNull(obj2);
                }
            };
        }
        return new Predicate() { // from class: com.scanflow.datacapture.barinternal.androidx.core.util.Predicate$$ExternalSyntheticLambda2
            @Override // androidx.core.util.Predicate
            public final boolean test(Object obj2) {
                return obj.equals(obj2);
            }
        };
    }

    @SuppressLint({"MissingNullability"})
    static <T> Predicate<T> not(@SuppressLint({"MissingNullability"}) Predicate<? super T> predicate) {
        Objects.requireNonNull(predicate);
        return predicate.negate();
    }
}
