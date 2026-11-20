.class public final Lcom/scanflow/datacapture/barinternal/h/a;
.super Landroidx/lifecycle/MutableLiveData;
.source "SourceFile"


# instance fields
.field public final a:Ljava/lang/String;

.field public final b:Ljava/lang/Object;

.field public final c:Landroid/content/SharedPreferences;

.field public final d:Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/Object;Landroid/content/SharedPreferences;)V
    .locals 1

    .line 1
    const-string v0, "key"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sharedPrefs"

    invoke-static {p3, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-direct {p0}, Landroidx/lifecycle/MutableLiveData;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->b:Ljava/lang/Object;

    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    new-instance p1, Lcom/scanflow/datacapture/barinternal/h/a$$ExternalSyntheticLambda0;

    invoke-direct {p1, p0}, Lcom/scanflow/datacapture/barinternal/h/a$$ExternalSyntheticLambda0;-><init>(Lcom/scanflow/datacapture/barinternal/h/a;)V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->d:Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;

    return-void
.end method

.method public static final a(Lcom/scanflow/datacapture/barinternal/h/a;Landroid/content/SharedPreferences;Ljava/lang/String;)V
    .locals 0

    .line 2
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    invoke-static {p2, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    if-eqz p1, :cond_0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/h/a;->a()Ljava/lang/Object;

    move-result-object p1

    invoke-virtual {p0, p1}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    :cond_0
    return-void
.end method


# virtual methods
.method public final a()Ljava/lang/Object;
    .locals 5

    .line 1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/h/a;->b:Ljava/lang/Object;

    instance-of v1, v0, Ljava/lang/Boolean;

    if-eqz v1, :cond_0

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    check-cast v0, Ljava/lang/Boolean;

    invoke-virtual {v0}, Ljava/lang/Boolean;->booleanValue()Z

    move-result v0

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences;->getBoolean(Ljava/lang/String;Z)Z

    move-result v0

    invoke-static {v0}, Ljava/lang/Boolean;->valueOf(Z)Ljava/lang/Boolean;

    move-result-object v0

    return-object v0

    :cond_0
    instance-of v1, v0, Ljava/lang/Integer;

    if-eqz v1, :cond_1

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->intValue()I

    move-result v0

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences;->getInt(Ljava/lang/String;I)I

    move-result v0

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    return-object v0

    :cond_1
    instance-of v1, v0, Ljava/lang/Long;

    if-eqz v1, :cond_2

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->longValue()J

    move-result-wide v3

    invoke-interface {v1, v2, v3, v4}, Landroid/content/SharedPreferences;->getLong(Ljava/lang/String;J)J

    move-result-wide v0

    invoke-static {v0, v1}, Ljava/lang/Long;->valueOf(J)Ljava/lang/Long;

    move-result-object v0

    return-object v0

    :cond_2
    instance-of v1, v0, Ljava/lang/String;

    if-eqz v1, :cond_4

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    check-cast v0, Ljava/lang/String;

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences;->getString(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    if-nez v0, :cond_3

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/h/a;->b:Ljava/lang/Object;

    check-cast v0, Ljava/lang/String;

    :cond_3
    return-object v0

    :cond_4
    instance-of v1, v0, Ljava/lang/Float;

    if-eqz v1, :cond_5

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    check-cast v0, Ljava/lang/Number;

    invoke-virtual {v0}, Ljava/lang/Number;->floatValue()F

    move-result v0

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences;->getFloat(Ljava/lang/String;F)F

    move-result v0

    invoke-static {v0}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v0

    return-object v0

    :cond_5
    instance-of v1, v0, Ljava/util/Set;

    if-eqz v1, :cond_6

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/h/a;->a:Ljava/lang/String;

    const-string v3, "null cannot be cast to non-null type kotlin.collections.Set<kotlin.String>"

    invoke-static {v0, v3}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    check-cast v0, Ljava/util/Set;

    invoke-interface {v1, v2, v0}, Landroid/content/SharedPreferences;->getStringSet(Ljava/lang/String;Ljava/util/Set;)Ljava/util/Set;

    move-result-object v0

    return-object v0

    :cond_6
    new-instance v0, Ljava/lang/IllegalArgumentException;

    const-string v1, "Unsupported SharedPreferences type. Currently supported types: [Boolean, Int, Long, Float, String, Set<String>]"

    invoke-direct {v0, v1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0
.end method

.method public final onActive()V
    .locals 2

    .line 1
    invoke-super {p0}, Landroidx/lifecycle/LiveData;->onActive()V

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/h/a;->a()Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0, v0}, Landroidx/lifecycle/MutableLiveData;->setValue(Ljava/lang/Object;)V

    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->d:Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;

    invoke-interface {v0, v1}, Landroid/content/SharedPreferences;->registerOnSharedPreferenceChangeListener(Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;)V

    return-void
.end method

.method public final onInactive()V
    .locals 2

    .line 1
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/h/a;->c:Landroid/content/SharedPreferences;

    iget-object v1, p0, Lcom/scanflow/datacapture/barinternal/h/a;->d:Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;

    invoke-interface {v0, v1}, Landroid/content/SharedPreferences;->unregisterOnSharedPreferenceChangeListener(Landroid/content/SharedPreferences$OnSharedPreferenceChangeListener;)V

    invoke-super {p0}, Landroidx/lifecycle/LiveData;->onInactive()V

    return-void
.end method
