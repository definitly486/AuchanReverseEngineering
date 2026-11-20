.class public abstract Lcom/scanflow/datacapture/barinternal/h/d;
.super Ljava/lang/Object;
.source "SourceFile"


# direct methods
.method public static final a(Landroid/content/SharedPreferences;Lcom/scanflow/datacapture/barinternal/kotlin/Pair;)Lcom/scanflow/datacapture/barinternal/h/a;
    .locals 2

    const-string v0, "<this>"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "pair"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    new-instance v1, Lcom/scanflow/datacapture/barinternal/h/a;

    .line 1
    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "sharedPrefs"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getFirst()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Ljava/lang/String;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Pair;->getSecond()Ljava/lang/Object;

    move-result-object p1

    invoke-direct {v1, v0, p1, p0}, Lcom/scanflow/datacapture/barinternal/h/a;-><init>(Ljava/lang/String;Ljava/lang/Object;Landroid/content/SharedPreferences;)V

    return-object v1
.end method
