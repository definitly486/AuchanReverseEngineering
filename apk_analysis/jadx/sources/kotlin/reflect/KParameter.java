package kotlin.reflect;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import kotlin.enums.EnumEntries;

/* JADX INFO: compiled from: KParameter.kt */
/* JADX INFO: loaded from: classes3.dex */
public interface KParameter extends KAnnotatedElement {

    /* JADX INFO: compiled from: KParameter.kt */
    public enum Kind {
        INSTANCE,
        CONTEXT,
        EXTENSION_RECEIVER,
        VALUE;

        private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

        public static EnumEntries<Kind> getEntries() {
            return $ENTRIES;
        }
    }

    int getIndex();

    Kind getKind();

    String getName();

    KType getType();

    boolean isOptional();

    boolean isVararg();
}
