package androidx.work;

import com.scanflow.datacapture.barinternal.kotlin.jvm.JvmClassMappingKt;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;

/* JADX INFO: compiled from: OneTimeWorkRequest.kt */
/* JADX INFO: loaded from: classes.dex */
public final class OneTimeWorkRequestKt {
    public static final OneTimeWorkRequest.Builder setInputMerger(OneTimeWorkRequest.Builder builder, KClass<? extends InputMerger> inputMerger) {
        Intrinsics.checkNotNullParameter(builder, "<this>");
        Intrinsics.checkNotNullParameter(inputMerger, "inputMerger");
        return builder.setInputMerger(JvmClassMappingKt.getJavaClass(inputMerger));
    }
}
