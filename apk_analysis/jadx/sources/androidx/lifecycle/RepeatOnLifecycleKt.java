package androidx.lifecycle;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuation;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CancellableContinuationImpl;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineScopeKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Job;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.MainCoroutineDispatcher;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync.Mutex;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.sync.MutexKt;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.DebugMetadata;
import kotlin.coroutines.jvm.internal.DebugProbesKt;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Ref$ObjectRef;
import kotlinx.coroutines.CoroutineScope;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: compiled from: RepeatOnLifecycle.kt */
/* JADX INFO: loaded from: classes.dex */
public final class RepeatOnLifecycleKt {
    public static final Object repeatOnLifecycle(Lifecycle lifecycle, Lifecycle.State state, Function2<? super CoroutineScope, ? super Continuation<? super Unit>, ? extends Object> function2, Continuation<? super Unit> continuation) {
        if (state == Lifecycle.State.INITIALIZED) {
            throw new IllegalArgumentException("repeatOnLifecycle cannot start work with the INITIALIZED lifecycle state.");
        }
        if (lifecycle.getCurrentState() == Lifecycle.State.DESTROYED) {
            return Unit.INSTANCE;
        }
        Object objCoroutineScope = CoroutineScopeKt.coroutineScope(new AnonymousClass3(lifecycle, state, function2, null), continuation);
        return objCoroutineScope == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objCoroutineScope : Unit.INSTANCE;
    }

    /* JADX INFO: renamed from: androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3, reason: invalid class name */
    /* JADX INFO: compiled from: RepeatOnLifecycle.kt */
    @DebugMetadata(c = "androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3", f = "RepeatOnLifecycle.kt", l = {83}, m = "invokeSuspend")
    static final class AnonymousClass3 extends SuspendLambda implements Function2<CoroutineScope, Continuation<? super Unit>, Object> {
        final /* synthetic */ Function2<CoroutineScope, Continuation<? super Unit>, Object> $block;
        final /* synthetic */ Lifecycle.State $state;
        final /* synthetic */ Lifecycle $this_repeatOnLifecycle;
        private /* synthetic */ Object L$0;
        int label;

        /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
        /* JADX WARN: Multi-variable type inference failed */
        AnonymousClass3(Lifecycle lifecycle, Lifecycle.State state, Function2<? super CoroutineScope, ? super Continuation<? super Unit>, ? extends Object> function2, Continuation<? super AnonymousClass3> continuation) {
            super(2, continuation);
            this.$this_repeatOnLifecycle = lifecycle;
            this.$state = state;
            this.$block = function2;
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Continuation<Unit> create(Object obj, Continuation<?> continuation) {
            AnonymousClass3 anonymousClass3 = new AnonymousClass3(this.$this_repeatOnLifecycle, this.$state, this.$block, continuation);
            anonymousClass3.L$0 = obj;
            return anonymousClass3;
        }

        @Override // kotlin.jvm.functions.Function2
        public final Object invoke(CoroutineScope coroutineScope, Continuation<? super Unit> continuation) {
            return ((AnonymousClass3) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
        }

        /* JADX INFO: renamed from: androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3$1, reason: invalid class name */
        /* JADX INFO: compiled from: RepeatOnLifecycle.kt */
        @DebugMetadata(c = "androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3$1", f = "RepeatOnLifecycle.kt", l = {BuiltinOperator.RIGHT_SHIFT}, m = "invokeSuspend")
        static final class AnonymousClass1 extends SuspendLambda implements Function2<CoroutineScope, Continuation<? super Unit>, Object> {
            final /* synthetic */ CoroutineScope $$this$coroutineScope;
            final /* synthetic */ Function2<CoroutineScope, Continuation<? super Unit>, Object> $block;
            final /* synthetic */ Lifecycle.State $state;
            final /* synthetic */ Lifecycle $this_repeatOnLifecycle;
            Object L$0;
            Object L$1;
            Object L$2;
            Object L$3;
            Object L$4;
            Object L$5;
            int label;

            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            /* JADX WARN: Multi-variable type inference failed */
            AnonymousClass1(Lifecycle lifecycle, Lifecycle.State state, CoroutineScope coroutineScope, Function2<? super CoroutineScope, ? super Continuation<? super Unit>, ? extends Object> function2, Continuation<? super AnonymousClass1> continuation) {
                super(2, continuation);
                this.$this_repeatOnLifecycle = lifecycle;
                this.$state = state;
                this.$$this$coroutineScope = coroutineScope;
                this.$block = function2;
            }

            @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
            public final Continuation<Unit> create(Object obj, Continuation<?> continuation) {
                return new AnonymousClass1(this.$this_repeatOnLifecycle, this.$state, this.$$this$coroutineScope, this.$block, continuation);
            }

            @Override // kotlin.jvm.functions.Function2
            public final Object invoke(CoroutineScope coroutineScope, Continuation<? super Unit> continuation) {
                return ((AnonymousClass1) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
            }

            /* JADX WARN: Code duplicated, block: B:28:0x00af  */
            /* JADX WARN: Code duplicated, block: B:31:0x00b8  */
            /* JADX WARN: Code duplicated, block: B:36:0x00c6  */
            /* JADX WARN: Code duplicated, block: B:39:0x00cf  */
            /* JADX WARN: Code duplicated, block: B:45:? A[SYNTHETIC] */
            @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
            public final Object invokeSuspend(Object obj) throws Throwable {
                Ref$ObjectRef ref$ObjectRef;
                Throwable th;
                Ref$ObjectRef ref$ObjectRef2;
                Job job;
                LifecycleEventObserver lifecycleEventObserver;
                Job job2;
                LifecycleEventObserver lifecycleEventObserver2;
                Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
                int i = this.label;
                if (i != 0) {
                    if (i != 1) {
                        throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                    }
                    ref$ObjectRef = (Ref$ObjectRef) this.L$1;
                    ref$ObjectRef2 = (Ref$ObjectRef) this.L$0;
                    try {
                        ResultKt.throwOnFailure(obj);
                        job2 = (Job) ref$ObjectRef2.element;
                        if (job2 != null) {
                            Job.DefaultImpls.cancel$default(job2, null, 1, null);
                        }
                        lifecycleEventObserver2 = (LifecycleEventObserver) ref$ObjectRef.element;
                        if (lifecycleEventObserver2 != null) {
                            this.$this_repeatOnLifecycle.removeObserver(lifecycleEventObserver2);
                        }
                        return Unit.INSTANCE;
                    } catch (Throwable th2) {
                        th = th2;
                        job = (Job) ref$ObjectRef2.element;
                        if (job != null) {
                            Job.DefaultImpls.cancel$default(job, null, 1, null);
                        }
                        lifecycleEventObserver = (LifecycleEventObserver) ref$ObjectRef.element;
                        if (lifecycleEventObserver != null) {
                            throw th;
                        }
                        this.$this_repeatOnLifecycle.removeObserver(lifecycleEventObserver);
                        throw th;
                    }
                }
                ResultKt.throwOnFailure(obj);
                if (this.$this_repeatOnLifecycle.getCurrentState() == Lifecycle.State.DESTROYED) {
                    return Unit.INSTANCE;
                }
                final Ref$ObjectRef ref$ObjectRef3 = new Ref$ObjectRef();
                ref$ObjectRef = new Ref$ObjectRef();
                try {
                    Lifecycle.State state = this.$state;
                    Lifecycle lifecycle = this.$this_repeatOnLifecycle;
                    final CoroutineScope coroutineScope = this.$$this$coroutineScope;
                    final Function2<CoroutineScope, Continuation<? super Unit>, Object> function2 = this.$block;
                    this.L$0 = ref$ObjectRef3;
                    this.L$1 = ref$ObjectRef;
                    this.L$2 = state;
                    this.L$3 = lifecycle;
                    this.L$4 = coroutineScope;
                    this.L$5 = function2;
                    this.label = 1;
                    final CancellableContinuationImpl cancellableContinuationImpl = new CancellableContinuationImpl(IntrinsicsKt.intercepted(this), 1);
                    cancellableContinuationImpl.initCancellability();
                    Lifecycle.Event.Companion companion = Lifecycle.Event.Companion;
                    final Lifecycle.Event eventUpTo = companion.upTo(state);
                    final Lifecycle.Event eventDownFrom = companion.downFrom(state);
                    final Mutex mutexMutex$default = MutexKt.Mutex$default(false, 1, null);
                    LifecycleEventObserver lifecycleEventObserver3 = new LifecycleEventObserver() { // from class: androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1
                        @Override // androidx.lifecycle.LifecycleEventObserver
                        public final void onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event) {
                            Intrinsics.checkNotNullParameter(lifecycleOwner, "<unused var>");
                            Intrinsics.checkNotNullParameter(event, "event");
                            if (event == eventUpTo) {
                                ref$ObjectRef3.element = BuildersKt__Builders_commonKt.launch$default(coroutineScope, null, null, new AnonymousClass1(mutexMutex$default, function2, null), 3, null);
                                return;
                            }
                            if (event == eventDownFrom) {
                                Job job3 = (Job) ref$ObjectRef3.element;
                                if (job3 != null) {
                                    Job.DefaultImpls.cancel$default(job3, null, 1, null);
                                }
                                ref$ObjectRef3.element = null;
                            }
                            if (event == Lifecycle.Event.ON_DESTROY) {
                                CancellableContinuation cancellableContinuation = cancellableContinuationImpl;
                                Result.Companion companion2 = Result.Companion;
                                cancellableContinuation.resumeWith(Result.m681constructorimpl(Unit.INSTANCE));
                            }
                        }

                        /* JADX INFO: renamed from: androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1$1, reason: invalid class name */
                        /* JADX INFO: compiled from: RepeatOnLifecycle.kt */
                        @DebugMetadata(c = "androidx.lifecycle.RepeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1$1", f = "RepeatOnLifecycle.kt", l = {165, 110}, m = "invokeSuspend")
                        static final class AnonymousClass1 extends SuspendLambda implements Function2<CoroutineScope, Continuation<? super Unit>, Object> {
                            final /* synthetic */ Function2<CoroutineScope, Continuation<? super Unit>, Object> $block;
                            final /* synthetic */ Mutex $mutex;
                            Object L$0;
                            Object L$1;
                            int label;

                            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
                            /* JADX WARN: Multi-variable type inference failed */
                            AnonymousClass1(Mutex mutex, Function2<? super CoroutineScope, ? super Continuation<? super Unit>, ? extends Object> function2, Continuation<? super AnonymousClass1> continuation) {
                                super(2, continuation);
                                this.$mutex = mutex;
                                this.$block = function2;
                            }

                            @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
                            public final Continuation<Unit> create(Object obj, Continuation<?> continuation) {
                                return new AnonymousClass1(this.$mutex, this.$block, continuation);
                            }

                            @Override // kotlin.jvm.functions.Function2
                            public final Object invoke(CoroutineScope coroutineScope, Continuation<? super Unit> continuation) {
                                return ((AnonymousClass1) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
                            }

                            @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
                            public final Object invokeSuspend(Object obj) throws Throwable {
                                Mutex mutex;
                                Function2<CoroutineScope, Continuation<? super Unit>, Object> function2;
                                Mutex mutex2;
                                Throwable th;
                                Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
                                int i = this.label;
                                try {
                                    if (i == 0) {
                                        ResultKt.throwOnFailure(obj);
                                        mutex = this.$mutex;
                                        function2 = this.$block;
                                        this.L$0 = mutex;
                                        this.L$1 = function2;
                                        this.label = 1;
                                        if (mutex.lock(null, this) != coroutine_suspended) {
                                        }
                                        return coroutine_suspended;
                                    }
                                    if (i != 1) {
                                        if (i != 2) {
                                            throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                                        }
                                        mutex2 = (Mutex) this.L$0;
                                        try {
                                            ResultKt.throwOnFailure(obj);
                                            Unit unit = Unit.INSTANCE;
                                            mutex2.unlock(null);
                                            return Unit.INSTANCE;
                                        } catch (Throwable th2) {
                                            th = th2;
                                            mutex2.unlock(null);
                                            throw th;
                                        }
                                    }
                                    function2 = (Function2) this.L$1;
                                    Mutex mutex3 = (Mutex) this.L$0;
                                    ResultKt.throwOnFailure(obj);
                                    mutex = mutex3;
                                    RepeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1$1$1$1 repeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1$1$1$1 = new RepeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1$1$1$1(function2, null);
                                    this.L$0 = mutex;
                                    this.L$1 = null;
                                    this.label = 2;
                                    if (CoroutineScopeKt.coroutineScope(repeatOnLifecycleKt$repeatOnLifecycle$3$1$1$1$1$1$1, this) != coroutine_suspended) {
                                        mutex2 = mutex;
                                        Unit unit2 = Unit.INSTANCE;
                                        mutex2.unlock(null);
                                        return Unit.INSTANCE;
                                    }
                                    return coroutine_suspended;
                                } catch (Throwable th3) {
                                    mutex2 = mutex;
                                    th = th3;
                                    mutex2.unlock(null);
                                    throw th;
                                }
                            }
                        }
                    };
                    ref$ObjectRef.element = lifecycleEventObserver3;
                    Intrinsics.checkNotNull(lifecycleEventObserver3, "null cannot be cast to non-null type androidx.lifecycle.LifecycleEventObserver");
                    lifecycle.addObserver(lifecycleEventObserver3);
                    Object result = cancellableContinuationImpl.getResult();
                    if (result == IntrinsicsKt.getCOROUTINE_SUSPENDED()) {
                        DebugProbesKt.probeCoroutineSuspended(this);
                    }
                    if (result == coroutine_suspended) {
                        return coroutine_suspended;
                    }
                    ref$ObjectRef2 = ref$ObjectRef3;
                    job2 = (Job) ref$ObjectRef2.element;
                    if (job2 != null) {
                        Job.DefaultImpls.cancel$default(job2, null, 1, null);
                    }
                    lifecycleEventObserver2 = (LifecycleEventObserver) ref$ObjectRef.element;
                    if (lifecycleEventObserver2 != null) {
                        this.$this_repeatOnLifecycle.removeObserver(lifecycleEventObserver2);
                    }
                    return Unit.INSTANCE;
                } catch (Throwable th3) {
                    th = th3;
                    ref$ObjectRef2 = ref$ObjectRef3;
                    job = (Job) ref$ObjectRef2.element;
                    if (job != null) {
                        Job.DefaultImpls.cancel$default(job, null, 1, null);
                    }
                    lifecycleEventObserver = (LifecycleEventObserver) ref$ObjectRef.element;
                    if (lifecycleEventObserver != null) {
                        throw th;
                    }
                    this.$this_repeatOnLifecycle.removeObserver(lifecycleEventObserver);
                    throw th;
                }
            }
        }

        @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
        public final Object invokeSuspend(Object obj) throws Throwable {
            Object coroutine_suspended = IntrinsicsKt.getCOROUTINE_SUSPENDED();
            int i = this.label;
            if (i == 0) {
                ResultKt.throwOnFailure(obj);
                CoroutineScope coroutineScope = (CoroutineScope) this.L$0;
                MainCoroutineDispatcher immediate = Dispatchers.getMain().getImmediate();
                AnonymousClass1 anonymousClass1 = new AnonymousClass1(this.$this_repeatOnLifecycle, this.$state, coroutineScope, this.$block, null);
                this.label = 1;
                if (BuildersKt.withContext(immediate, anonymousClass1, this) == coroutine_suspended) {
                    return coroutine_suspended;
                }
            } else {
                if (i != 1) {
                    throw new IllegalStateException("call to 'resume' before 'invoke' with coroutine");
                }
                ResultKt.throwOnFailure(obj);
            }
            return Unit.INSTANCE;
        }
    }

    public static final Object repeatOnLifecycle(LifecycleOwner lifecycleOwner, Lifecycle.State state, Function2<? super CoroutineScope, ? super Continuation<? super Unit>, ? extends Object> function2, Continuation<? super Unit> continuation) {
        Object objRepeatOnLifecycle = repeatOnLifecycle(lifecycleOwner.getLifecycle(), state, function2, continuation);
        return objRepeatOnLifecycle == IntrinsicsKt.getCOROUTINE_SUSPENDED() ? objRepeatOnLifecycle : Unit.INSTANCE;
    }
}
