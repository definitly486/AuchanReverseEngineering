package kotlinx.serialization;

import com.scanflow.datacapture.barinternal.kotlin.enums.EnumEntriesKt;
import java.lang.annotation.Documented;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;
import kotlin.enums.EnumEntries;

/* JADX WARN: Method from annotation default annotation not found: mode */
/* JADX INFO: compiled from: Annotations.kt */
/* JADX INFO: loaded from: classes3.dex */
@Target({})
@ExperimentalSerializationApi
@Documented
@Retention(RetentionPolicy.RUNTIME)
public @interface EncodeDefault {

    /* JADX INFO: compiled from: Annotations.kt */
    @ExperimentalSerializationApi
    public enum Mode {
        ALWAYS,
        NEVER;

        private static final /* synthetic */ EnumEntries $ENTRIES = EnumEntriesKt.enumEntries(values());

        public static EnumEntries<Mode> getEntries() {
            return $ENTRIES;
        }
    }
}
