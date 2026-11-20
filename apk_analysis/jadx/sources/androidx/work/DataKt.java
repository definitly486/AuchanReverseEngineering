package androidx.work;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Data.kt */
/* JADX INFO: loaded from: classes.dex */
public final class DataKt {
    public static final Data workDataOf(Pair... pairs) {
        Intrinsics.checkNotNullParameter(pairs, "pairs");
        Data.Builder builder = new Data.Builder();
        for (Pair pair : pairs) {
            builder.put((String) pair.getFirst(), pair.getSecond());
        }
        return builder.build();
    }
}
