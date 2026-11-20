package androidx.lifecycle.internal;

import android.os.Bundle;
import androidx.lifecycle.internal.SavedStateHandleImpl;
import androidx.savedstate.SavedStateRegistry;
import com.scanflow.datacapture.barinternal.androidx.core.os.BundleKt;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateWriter;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.FlowKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.MutableStateFlow;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.flow.StateFlowKt;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.flow.StateFlow;

/* JADX INFO: compiled from: SavedStateHandleImpl.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SavedStateHandleImpl {
    private final Map<String, MutableStateFlow> flows;
    private final Map<String, MutableStateFlow> mutableFlows;
    private final Map<String, SavedStateRegistry.SavedStateProvider> providers;
    private final Map<String, Object> regular;
    private final SavedStateRegistry.SavedStateProvider savedStateProvider;

    /* JADX WARN: Multi-variable type inference failed */
    public SavedStateHandleImpl() {
        this(null, 1, 0 == true ? 1 : 0);
    }

    public SavedStateHandleImpl(Map<String, ? extends Object> initialState) {
        Intrinsics.checkNotNullParameter(initialState, "initialState");
        this.regular = MapsKt.toMutableMap(initialState);
        this.providers = new LinkedHashMap();
        this.flows = new LinkedHashMap();
        this.mutableFlows = new LinkedHashMap();
        this.savedStateProvider = new SavedStateRegistry.SavedStateProvider() { // from class: com.scanflow.datacapture.barinternal.androidx.lifecycle.internal.SavedStateHandleImpl$$ExternalSyntheticLambda0
            @Override // androidx.savedstate.SavedStateRegistry.SavedStateProvider
            public final Bundle saveState() {
                return SavedStateHandleImpl.savedStateProvider$lambda$0(this.f$0);
            }
        };
    }

    public /* synthetic */ SavedStateHandleImpl(Map map, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? MapsKt.emptyMap() : map);
    }

    public final Map<String, Object> getRegular() {
        return this.regular;
    }

    public final Map<String, MutableStateFlow> getMutableFlows() {
        return this.mutableFlows;
    }

    public final SavedStateRegistry.SavedStateProvider getSavedStateProvider() {
        return this.savedStateProvider;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Bundle savedStateProvider$lambda$0(SavedStateHandleImpl savedStateHandleImpl) {
        Pair[] pairArr;
        for (Map.Entry entry : MapsKt.toMap(savedStateHandleImpl.mutableFlows).entrySet()) {
            savedStateHandleImpl.set((String) entry.getKey(), ((MutableStateFlow) entry.getValue()).getValue());
        }
        for (Map.Entry entry2 : MapsKt.toMap(savedStateHandleImpl.providers).entrySet()) {
            savedStateHandleImpl.set((String) entry2.getKey(), ((SavedStateRegistry.SavedStateProvider) entry2.getValue()).saveState());
        }
        Map<String, Object> map = savedStateHandleImpl.regular;
        if (map.isEmpty()) {
            pairArr = new Pair[0];
        } else {
            ArrayList arrayList = new ArrayList(map.size());
            for (Map.Entry<String, Object> entry3 : map.entrySet()) {
                arrayList.add(TuplesKt.to(entry3.getKey(), entry3.getValue()));
            }
            pairArr = (Pair[]) arrayList.toArray(new Pair[0]);
        }
        Bundle bundleBundleOf = BundleKt.bundleOf((Pair[]) Arrays.copyOf(pairArr, pairArr.length));
        SavedStateWriter.m591constructorimpl(bundleBundleOf);
        return bundleBundleOf;
    }

    public final SavedStateRegistry.SavedStateProvider savedStateProvider() {
        return this.savedStateProvider;
    }

    public final boolean contains(String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        return this.regular.containsKey(key);
    }

    public final <T> StateFlow<T> getStateFlow(String key, T t) {
        Intrinsics.checkNotNullParameter(key, "key");
        Map<String, MutableStateFlow> map = this.flows;
        MutableStateFlow MutableStateFlow = map.get(key);
        if (MutableStateFlow == null) {
            if (!this.regular.containsKey(key)) {
                this.regular.put(key, t);
            }
            MutableStateFlow = StateFlowKt.MutableStateFlow(this.regular.get(key));
            map.put(key, MutableStateFlow);
        }
        StateFlow<T> stateFlowAsStateFlow = FlowKt.asStateFlow(MutableStateFlow);
        Intrinsics.checkNotNull(stateFlowAsStateFlow, "null cannot be cast to non-null type kotlinx.coroutines.flow.StateFlow<T of androidx.lifecycle.internal.SavedStateHandleImpl.getStateFlow>");
        return stateFlowAsStateFlow;
    }

    public final <T> MutableStateFlow getMutableStateFlow(String key, T t) {
        Intrinsics.checkNotNullParameter(key, "key");
        Map<String, MutableStateFlow> map = this.mutableFlows;
        MutableStateFlow MutableStateFlow = map.get(key);
        if (MutableStateFlow == null) {
            if (!this.regular.containsKey(key)) {
                this.regular.put(key, t);
            }
            MutableStateFlow = StateFlowKt.MutableStateFlow(this.regular.get(key));
            map.put(key, MutableStateFlow);
        }
        MutableStateFlow mutableStateFlow = MutableStateFlow;
        Intrinsics.checkNotNull(mutableStateFlow, "null cannot be cast to non-null type kotlinx.coroutines.flow.MutableStateFlow<T of androidx.lifecycle.internal.SavedStateHandleImpl.getMutableStateFlow>");
        return mutableStateFlow;
    }

    public final Set<String> keys() {
        return SetsKt.plus(this.regular.keySet(), this.providers.keySet());
    }

    public final <T> T get(String key) {
        T t;
        Intrinsics.checkNotNullParameter(key, "key");
        try {
            MutableStateFlow mutableStateFlow = this.mutableFlows.get(key);
            if (mutableStateFlow != null && (t = (T) mutableStateFlow.getValue()) != null) {
                return t;
            }
            return (T) this.regular.get(key);
        } catch (ClassCastException unused) {
            remove(key);
            return null;
        }
    }

    public final <T> void set(String key, T t) {
        Intrinsics.checkNotNullParameter(key, "key");
        this.regular.put(key, t);
        MutableStateFlow mutableStateFlow = this.flows.get(key);
        if (mutableStateFlow != null) {
            mutableStateFlow.setValue(t);
        }
        MutableStateFlow mutableStateFlow2 = this.mutableFlows.get(key);
        if (mutableStateFlow2 != null) {
            mutableStateFlow2.setValue(t);
        }
    }

    public final <T> T remove(String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        T t = (T) this.regular.remove(key);
        this.flows.remove(key);
        this.mutableFlows.remove(key);
        return t;
    }

    public final void setSavedStateProvider(String key, SavedStateRegistry.SavedStateProvider provider) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(provider, "provider");
        this.providers.put(key, provider);
    }

    public final void clearSavedStateProvider(String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        this.providers.remove(key);
    }
}
