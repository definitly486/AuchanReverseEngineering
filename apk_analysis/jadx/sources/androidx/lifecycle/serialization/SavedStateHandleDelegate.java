package androidx.lifecycle.serialization;

import android.os.Bundle;
import androidx.lifecycle.SavedStateHandle;
import androidx.lifecycle.internal.CanonicalName_jvmKt;
import androidx.savedstate.SavedStateRegistry;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateConfiguration;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateDecoderKt;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.SavedStateEncoderKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.properties.ReadWriteProperty;
import com.scanflow.datacapture.barinternal.kotlin.reflect.KProperty;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;
import kotlinx.serialization.KSerializer;

/* JADX INFO: compiled from: SavedStateHandleDelegate.kt */
/* JADX INFO: loaded from: classes.dex */
final class SavedStateHandleDelegate<T> implements ReadWriteProperty {
    private final SavedStateConfiguration configuration;
    private final Function0<T> init;
    private final String key;
    private final SavedStateHandle savedStateHandle;
    private final KSerializer<T> serializer;
    private T value;

    /* JADX WARN: Multi-variable type inference failed */
    public SavedStateHandleDelegate(SavedStateHandle savedStateHandle, KSerializer<T> serializer, String str, SavedStateConfiguration configuration, Function0<? extends T> init) {
        Intrinsics.checkNotNullParameter(savedStateHandle, "savedStateHandle");
        Intrinsics.checkNotNullParameter(serializer, "serializer");
        Intrinsics.checkNotNullParameter(configuration, "configuration");
        Intrinsics.checkNotNullParameter(init, "init");
        this.savedStateHandle = savedStateHandle;
        this.serializer = serializer;
        this.key = str;
        this.configuration = configuration;
        this.init = init;
    }

    private final T loadValue(String str) {
        Bundle bundle = (Bundle) this.savedStateHandle.get(str);
        if (bundle != null) {
            return (T) SavedStateDecoderKt.decodeFromSavedState(this.serializer, bundle, this.configuration);
        }
        return null;
    }

    private final void registerSave(String str) {
        this.savedStateHandle.setSavedStateProvider(str, new SavedStateRegistry.SavedStateProvider() { // from class: androidx.lifecycle.serialization.SavedStateHandleDelegate$$ExternalSyntheticLambda0
            @Override // androidx.savedstate.SavedStateRegistry.SavedStateProvider
            public final Bundle saveState() {
                return SavedStateHandleDelegate.registerSave$lambda$1(this.f$0);
            }
        });
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Bundle registerSave$lambda$1(SavedStateHandleDelegate savedStateHandleDelegate) {
        KSerializer<T> kSerializer = savedStateHandleDelegate.serializer;
        Object obj = savedStateHandleDelegate.value;
        if (obj == null) {
            Intrinsics.throwUninitializedPropertyAccessException("value");
            obj = Unit.INSTANCE;
        }
        return SavedStateEncoderKt.encodeToSavedState(kSerializer, obj, savedStateHandleDelegate.configuration);
    }

    private final String createDefaultKey(Object obj, KProperty kProperty) {
        String str;
        if (obj != null) {
            str = CanonicalName_jvmKt.getCanonicalName(Reflection.getOrCreateKotlinClass(obj.getClass())) + '.';
        } else {
            str = "";
        }
        return str + kProperty.getName();
    }

    public T getValue(Object obj, KProperty property) {
        Intrinsics.checkNotNullParameter(property, "property");
        if (this.value == null) {
            String strCreateDefaultKey = this.key;
            if (strCreateDefaultKey == null) {
                strCreateDefaultKey = createDefaultKey(obj, property);
            }
            registerSave(strCreateDefaultKey);
            T tLoadValue = loadValue(strCreateDefaultKey);
            if (tLoadValue == null) {
                tLoadValue = this.init.invoke();
            }
            this.value = tLoadValue;
        }
        T t = this.value;
        if (t != null) {
            return t;
        }
        Intrinsics.throwUninitializedPropertyAccessException("value");
        return (T) Unit.INSTANCE;
    }

    public void setValue(Object obj, KProperty property, T value) {
        Intrinsics.checkNotNullParameter(property, "property");
        Intrinsics.checkNotNullParameter(value, "value");
        if (this.value == null) {
            String strCreateDefaultKey = this.key;
            if (strCreateDefaultKey == null) {
                strCreateDefaultKey = createDefaultKey(obj, property);
            }
            registerSave(strCreateDefaultKey);
        }
        this.value = value;
    }
}
